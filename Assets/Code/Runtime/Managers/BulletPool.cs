using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : AComponentPool<Bullet>
{
	protected override Bullet Prefab
		=> Settings.Game.BulletPrefab;
	protected override int MaxActive
		=> Mathf.RoundToInt(Settings.UI.CubeToggleAmounts.Max() * Settings.Game.BulletLifetime / Settings.Game.ShooterShootInterval);
}
