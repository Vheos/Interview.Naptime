using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(UISettings), menuName = "Settings/" + nameof(UISettings))]
public class UISettings : ScriptableObject
{
	[SerializeField] private Color fontShadow;
	[SerializeField] private Color mainBackground;
	[SerializeField] private Color gameOverBar;
}
