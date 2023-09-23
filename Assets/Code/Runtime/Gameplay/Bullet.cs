using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private new SphereCollider collider;

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
	public SphereCollider Collider
		=> collider;

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
		Vector3 position = transform.position;
		float radius = collider.radius;
		LayerMask layerMask = GameManager.ShooterLayerMask;

		if (!Physics.CheckSphere(position, radius, layerMask))
			return false;

		Collider[] colliders = new Collider[1];
		Physics.OverlapSphereNonAlloc(position, radius, colliders, layerMask);
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