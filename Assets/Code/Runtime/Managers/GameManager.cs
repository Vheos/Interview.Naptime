using Assets.Code.Runtime;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField, Range(0.1f, 10f)] private float timeScale;
	[SerializeField] private new Camera camera;
	[SerializeField] private CanvasManager rootCanvas;
	[SerializeField] private ShooterPool shooterPool;
	[SerializeField] private BulletPool bulletPool;


	private void Awake()
	{
		instance = this;
		DOTween.SetTweensCapacity(1000, 50);
		AddScene(SceneName.Game);
		ShowMainMenu();
	}
	private void Update()
	{
		if (CanForceEndGame && Keyboard.current.escapeKey.wasPressedThisFrame)
			EndGame();
		Time.timeScale = timeScale;
	}

	private static GameManager instance;

	private static bool CanForceEndGame { get; set; }
	public static int ShooterLayerMask { get; private set; }

	public static void ShowMainMenu()
	{
		instance.rootCanvas.ChangeScreen(UIScreen.StartMenu);
	}
	public static void StartGame(int shootersToSpawn)
	{
		instance.rootCanvas.ChangeScreen(UIScreen.None);
		ActivateScene(SceneName.Game);

		float shooterRadius = Settings.Game.ShooterPrefab.Collider.radius;
		float spawnRadiusIncrement = shooterRadius / Mathf.Pow(2, Settings.Game.ShooterSpawnDensity);
		Helpers.FindSpawnPointsInCircle(shootersToSpawn, shooterRadius, shooterRadius, spawnRadiusIncrement,
			out var spawnPoints, out var maxSpawnRadius);

		StartCoroutine(SpawnShootersCoroutine(spawnPoints, Settings.Game.ShooterSpawnInterval));

		float targetFrustumHeight = (maxSpawnRadius + shooterRadius) * 2;
		float cameraDistance = Helpers.CameraDistance(targetFrustumHeight, instance.camera.fieldOfView);
		instance.camera.SetDistance(Vector3.zero, cameraDistance);

		CanForceEndGame = true;
	}
	private static IEnumerator SpawnShootersCoroutine(IEnumerable<Vector2> spawnPoints, float spawnInterval)
	{
		foreach (var spawnPoint in spawnPoints)
		{
			SpawnShooter(spawnPoint);
			if (spawnInterval > 0)
				yield return new WaitForSeconds(spawnInterval);
		}
	}
	private static void CheckEndGame()
	{
		if (instance.shooterPool.ActiveComponentsCount <= 1)
			EndGame();
	}
	private static void EndGame()
	{
		CanForceEndGame = false;
		instance.shooterPool.ReleaseAll();
		instance.bulletPool.ReleaseAll();

		ActivateScene(SceneName.Persistent);
		instance.rootCanvas.ChangeScreen(UIScreen.GameOver);
	}

	private static Shooter SpawnShooter(Vector3 position)
	{
		Shooter newShooter = instance.shooterPool.Get();
		newShooter.transform.position = position;
		newShooter.OnDeath += CheckEndGame;
		return newShooter;
	}
	public static Bullet SpawnBullet(Vector3 position, Vector3 direction)
	{
		Bullet newBullet = instance.bulletPool.Get();
		newBullet.transform.position = position;
		newBullet.Direction = direction;
		return newBullet;
	}
	public static void Despawn(Shooter shooter)
	{
		shooter.OnDeath -= CheckEndGame;
		instance.shooterPool.Release(shooter);
	}
	public static void Despawn(Bullet bullet)
		=> instance.bulletPool.Release(bullet);
	public static new Coroutine StartCoroutine(IEnumerator enumerator)
		=> ((MonoBehaviour)instance).StartCoroutine(enumerator);

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void StaticInitialize()
	{
		instance = null;
		ShooterLayerMask = LayerMask.GetMask(Layers.Shooter.ToString());
	}
}
