using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float despawnTime;
	private Vector3 direction;
	public Vector3 Direction
	{
		get => direction;
		set
		{
			if (value == Vector3.zero)
				return;

			direction = value.normalized;
		}
	}

	private void UpdateDespawnTime()
	=> despawnTime = Time.time + Settings.Game.BulletLifetime;
	private bool CheckDespawn()
	{
		if (Time.time < despawnTime)
			return false;

		GameManager.Despawn(this);
		return true;
	}
	private void Move()
		=> transform.position += Time.deltaTime * Settings.Game.BulletSpeed * direction;
	private bool CheckHit()
	{
		if (!Physics.CheckSphere(transform.position, Settings.Game.BulletRadius, GameManager.ShooterLayerMask))
			return false;

		Collider[] colliders = new Collider[1];
		Physics.OverlapSphereNonAlloc(transform.position, Settings.Game.BulletRadius, colliders, GameManager.ShooterLayerMask);
		Shooter hitShooter = colliders[0].GetComponent<Shooter>();
		hitShooter.Health--;

		GameManager.Despawn(this);
		return true;
	}

	private void OnEnable()
	{
		UpdateDespawnTime();
	}
	private void Update()
	{
		if (CheckDespawn())
			return;

		Move();
	}
	private void FixedUpdate()
	{
		CheckHit();
	}
}