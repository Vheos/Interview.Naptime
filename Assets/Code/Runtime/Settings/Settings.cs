using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Settings : MonoBehaviour
{
	[SerializeField] private UISettings uiSettings;
	[SerializeField] private GameSettings gameSettings;

	private void Awake()
	{
		UI = uiSettings;
		Game = gameSettings;
	}

	public static UISettings UI { private set; get; }
	public static GameSettings Game { private set; get; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void StaticInitialize()
	{
		UI = null;
		Game = null;
	}
}
