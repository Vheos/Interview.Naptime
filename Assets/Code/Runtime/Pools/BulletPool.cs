using System.Linq;
using UnityEngine;

public class BulletPool : AComponentPool<Bullet>
{
	protected override Bullet Prefab
		=> Settings.Game.BulletPrefab;
	protected override int MaxActive
		=> Mathf.RoundToInt(Settings.UI.CubeToggleAmounts.Max() * Settings.Game.BulletLifetime / Settings.Game.ShooterShootInterval);
}
