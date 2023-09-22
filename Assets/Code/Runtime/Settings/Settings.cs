using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Settings : MonoBehaviour
{
    [SerializeField] UISettings uiSettings;
	[SerializeField] GameSettings gameSettings;

	private void Awake()
	{
		UI = uiSettings;
		Game = gameSettings;
	}

	static public UISettings UI { private set; get; }
	static public GameSettings Game { private set; get; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	static private void StaticInitialize()
	{
		UI = null;
		Game = null;
	}
}
