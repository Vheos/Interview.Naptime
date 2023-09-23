using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Vector3 direction;
	private float despawnTime;

	public void Initialize(Vector3 position, Vector3 direction)
	{
		transform.position = position;
		this.direction = direction.normalized;
		despawnTime = Time.time + Settings.Game.BulletLifetime;
	}
	private void Move()
		=> transform.position += Time.deltaTime * Settings.Game.BulletSpeed * direction;
	private bool CheckDespawn()
	{
		if (Time.time < despawnTime)
			return false;

		GameManager.Despawn(this);
		return true;
	}

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