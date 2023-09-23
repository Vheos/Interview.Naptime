using Assets.Code.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	[SerializeField, Range(0.1f, 10f)] float timeScale;
	[SerializeField] new Camera camera;
	[SerializeField] CanvasManager rootCanvas;
	[SerializeField] ShooterPool shooterPool;
	[SerializeField] BulletPool bulletPool;

	private void Awake()
	{
		instance = this;
		instance.rootCanvas.ChangeScreen(UIScreen.StartMenu);
	}
	private void FixedUpdate()
	{
		Time.timeScale = timeScale;
	}

	static private GameManager instance;
	private static int cameraDistance;

	static public int ShooterLayerMask { get; private set; }

	static private void ActivateScene(SceneName sceneName)
	{
		Scene gameScene = SceneManager.GetSceneByName(sceneName.ToString());
		SceneManager.SetActiveScene(gameScene);
	}
	static public void StartGame(int shootersToSpawn)
	{
		instance.rootCanvas.ChangeScreen(UIScreen.None);
		ActivateScene(SceneName.Game);

		float shooterRadius = Settings.Game.ShooterPrefab.Collider.radius;
		Helpers.FindSpawnPoints2D(shootersToSpawn, shooterRadius, shooterRadius, shooterRadius / 2f, out var spawnPoints, out var maxSpawnRadius);

		StartCoroutine(SpawnShootersCoroutine(spawnPoints.Select(v => (Vector3)v), Settings.Game.ShooterSpawnInterval));

		float cameraDistance = Helpers.CameraDistance(maxSpawnRadius * 2, instance.camera.fieldOfView);
		instance.camera.SetDistance(Vector3.zero, cameraDistance);
	}

	static private IEnumerator SpawnShootersCoroutine(IEnumerable<Vector3> spawnPoints, float spawnInterval)
	{
		foreach (var spawnPoint in spawnPoints)
		{
			SpawnShooter(spawnPoint);
			if (spawnInterval > 0)
				yield return new WaitForSeconds(spawnInterval);
		}
	}

	static private void CheckEndGame()
	{
		if (instance.shooterPool.ActiveComponentsCount <= 1)
			EndGame();
	}
	static private void EndGame()
	{
		instance.shooterPool.ReleaseAll();
		instance.bulletPool.ReleaseAll();

		ActivateScene(SceneName.Persistent);
		instance.rootCanvas.ChangeScreen(UIScreen.StartMenu);
	}

	private static Shooter SpawnShooter(Vector3 position)
	{
		Shooter newShooter = instance.shooterPool.Get();
		newShooter.transform.position = position;
		newShooter.OnDeath += CheckEndGame;
		return newShooter;
	}
	static public Bullet SpawnBullet(Vector3 position, Vector3 direction)
	{
		Bullet newBullet = instance.bulletPool.Get();
		newBullet.transform.position = position;
		newBullet.Direction = direction;
		return newBullet;
	}

	static public void Despawn(Shooter shooter)
		=> instance.shooterPool.Release(shooter);
	static public void Despawn(Bullet bullet)
		=> instance.bulletPool.Release(bullet);
	static public new Coroutine StartCoroutine(IEnumerator enumerator)
		=> ((MonoBehaviour)instance).StartCoroutine(enumerator);

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	static private void StaticInitialize()
	{
		instance = null;
		ShooterLayerMask = LayerMask.GetMask(Layers.Shooter.ToString());
	}
}
