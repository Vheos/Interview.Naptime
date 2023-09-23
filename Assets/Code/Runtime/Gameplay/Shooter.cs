using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
	[SerializeField] Transform bulletSpawnPoint;

	private int health;
	public int Health
	{
		get => health;
		set
		{
			int previousHealth = health;
			health = value;
			if (health == previousHealth)
				return;

			OnHealthChanged?.Invoke(previousHealth, health);

			if (health < previousHealth)
				GameManager.StartCoroutine(TakeDamageCoroutine());
		}
	}
	private float nextRotateTime;
	private float nextShootTime;

	public event Action<int, int> OnHealthChanged;
	public event Action OnDeath;

	private void InitializeHealth()
		=> health = Settings.Game.ShooterHealth;
	private void UpdateNextRotateTime()
	{
		Vector2 intervalRange = Settings.Game.ShooterRotateInterval;
		float interval = Random.Range(intervalRange.x, intervalRange.y);
		nextRotateTime = Time.time + interval;
	}
	private void UpdateNextShootTime()
		=> nextShootTime = Time.time + Settings.Game.ShooterShootInterval;
	private void CheckRotate()
	{
		if (Time.time < nextRotateTime)
			return;

		Vector2 angleRange = Settings.Game.ShooterRotateAngle;
		float angle = Random.Range(angleRange.x, angleRange.y);
		transform.Rotate(Vector3.forward, angle, Space.World);
		UpdateNextRotateTime();
	}
	private void CheckShoot()
	{
		if (Time.time < nextShootTime)
			return;

		GameManager.SpawnBullet(bulletSpawnPoint.position, transform.forward);
		UpdateNextShootTime();
	}
	private IEnumerator TakeDamageCoroutine()
	{
		if (Health <= 0)
		{
			GameManager.Despawn(this);
			OnDeath?.Invoke();
			yield break;
		}

		gameObject.SetActive(false);
		yield return new WaitForSeconds(Settings.Game.ShooterRespawnInterval);
		if (this != null)
			gameObject.SetActive(true);

	}

	private void Awake()
	{
		InitializeHealth();
	}
	private void OnEnable()
	{
		UpdateNextRotateTime();
		UpdateNextShootTime();
	}
	private void Update()
	{
		CheckRotate();
		CheckShoot();
	}
}