using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(UISettings), menuName = "Settings/" + nameof(UISettings))]
public class UISettings : ScriptableObject
{
	[field: SerializeField] public Color FontShadow { get; private set; }
	[field: SerializeField] public Color MainBackground { get; private set; }
	[field: SerializeField] public Color GameOverBar { get; private set; }
	[field: SerializeField, Range(2, 500)] public int[] CubeToggleAmounts { get; private set; }
	[field: SerializeField] public Color[] CubeToggleIconColors { get; private set; }
}
