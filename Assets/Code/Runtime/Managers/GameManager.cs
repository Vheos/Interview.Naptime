using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] RootCanvas rootCanvas;

	private void Awake()
	{
		instance = this;
		instance.rootCanvas.ChangeScreen(UIScreen.StartMenu);		
	}

	static private GameManager instance;

	static public void ActivateScene(SceneName sceneName)
	{
		Scene gameScene = SceneManager.GetSceneByName(sceneName.ToString());
		SceneManager.SetActiveScene(gameScene);
	}
	static public void StartGame(int cubesToSpawn)
	{
		instance.rootCanvas.ChangeScreen(UIScreen.None);
		ActivateScene(SceneName.Game);
	}
	static public void EndGame()
	{
		ActivateScene(SceneName.Persistent);
		instance.rootCanvas.ChangeScreen(UIScreen.GameOver);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	static private void StaticInitialize()
	{
		instance = null;
	}
}
