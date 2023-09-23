using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
	[SerializeField] Button button;
	[SerializeField] Image icon;

	private void OnButtonClicked()
	{
		GameManager.ShowMainMenu();
	}

	private void OnEnable()
	{
		button.onClick.AddListener(OnButtonClicked);
	}
	private void OnDisable()
	{
		button.onClick.RemoveListener(OnButtonClicked);
	}
}