using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(UISettings), menuName = "Settings/" + nameof(UISettings))]
public class UISettings : ScriptableObject
{
	[field: Header("General")]
	[field: SerializeField] public Color FontShadow { get; private set; }
	[field: SerializeField] public Color MainBackground { get; private set; }
	[field: SerializeField] public Color GameOverBar { get; private set; }

	[field: Header("Cube Menu")]
	[field: SerializeField] public CubeToggle CubeTogglePrefab { get; private set; }
	[field: SerializeField, Range(2, 500)] public int[] CubeToggleAmounts { get; private set; }
	[field: SerializeField] public Color[] CubeToggleIconColors { get; private set; }
	[field: SerializeField, Range(1f, 1.5f)] public float SelectedToggleScale { get; private set; }
	
}
