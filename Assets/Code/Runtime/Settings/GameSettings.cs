using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Settings/" + nameof(GameSettings))]
public class GameSettings : ScriptableObject
{
	[field: Header("General")]
	[field: SerializeField] public Shooter ShooterPrefab { get; private set; }
	[field: SerializeField] public Bullet BulletPrefab { get; private set; }
}
