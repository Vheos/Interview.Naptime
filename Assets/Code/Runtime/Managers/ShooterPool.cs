using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class ShooterPool : AComponentPool<Shooter>
{
	protected override int MaxActive
		=> Settings.UI.CubeToggleAmounts.Max();
}
