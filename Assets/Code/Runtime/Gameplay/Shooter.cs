using Assets.Code.Runtime;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
	[SerializeField] private new SphereCollider collider;
	[SerializeField] private GameObject visuals;
	[SerializeField] private Transform bulletSpawnPoint;

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
	public SphereCollider Collider
		=> collider;

	public event Action<int, int> OnHealthChanged;
	public event Action OnDeath;

	private void InitializeHealth()
		=> health = Settings.Game.ShooterHealth;
	private void UpdateNextRotateTime()
	{
		nextRotateTime = Time.time + Settings.Game.ShooterRotateInterval.RandomRange();
	}
	private void CheckRotate()
	{
		if (Time.time < nextRotateTime)
			return;

		UpdateNextRotateTime();
		Rotate();
	}
	private void Rotate()
	{
		float angle = Settings.Game.ShooterRotateAngle.RandomRange();
		Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward) * transform.rotation;

		if (Settings.Game.UseTweens)
			transform.DORotateQuaternion(targetRotation, nextRotateTime - Time.time);
		else
			transform.rotation = targetRotation;
	}
	private void UpdateNextShootTime()
		=> nextShootTime = Time.time + Settings.Game.ShooterShootInterval;
	private void CheckShoot()
	{
		if (Time.time < nextShootTime)
			return;

		UpdateNextShootTime();
		Shoot();
	}
	private void Shoot()
		=> GameManager.SpawnBullet(bulletSpawnPoint.position, transform.forward); private IEnumerator TakeDamageCoroutine()
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
		if (Settings.Game.UseTweens)
		{
			visuals.transform.localScale = Vector3.zero;
			visuals.transform.DOScale(1f, 1f);
		}
		UpdateNextRotateTime();
		UpdateNextShootTime();
	}
	private void Update()
	{
		CheckRotate();
		CheckShoot();
	}
}