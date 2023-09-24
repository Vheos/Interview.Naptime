using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Settings/" + nameof(GameSettings))]
public class GameSettings : ScriptableObject
{
	[field: Header("General")]
	[field: SerializeField] public bool UseTweens { get; private set; }

	[field: Header("Shooter")]
	[field: SerializeField] public Shooter ShooterPrefab { get; private set; }
	[field: SerializeField, Range(1, 5)] public int ShooterHealth { get; private set; }
	[field: SerializeField] public Vector2 ShooterRotateAngle { get; private set; }
	[field: SerializeField] public Vector2 ShooterRotateInterval { get; private set; }
	[field: SerializeField, Range(0.5f, 2f)] public float ShooterShootInterval { get; private set; }
	[field: SerializeField, Range(0f, 5f)] public float ShooterRespawnInterval { get; private set; }
	[field: SerializeField, Range(0f, 1f)] public float ShooterSpawnInterval { get; private set; }

	[field: Header("Bullet")]
	[field: SerializeField] public Bullet BulletPrefab { get; private set; }
	[field: SerializeField, Range(0.1f, 20f)] public float BulletSpeed { get; private set; }
	[field: SerializeField, Range(0f, 1f)] public float BulletRadius { get; internal set; }
	[field: SerializeField, Range(1f, 60f)] public float BulletLifetime { get; private set; }
}
