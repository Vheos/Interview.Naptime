using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
	[SerializeField] Button button;
	[SerializeField] Image icon;
	[SerializeField] CubeToggleGroup cubeToggleGroup;

	private void OnCubeToggleChanged(CubeToggle previousToggle, CubeToggle currentToggle)
	{
		bool state = currentToggle != null;
		button.interactable = state;
		icon.enabled = state;
	}
	private void OnButtonClicked()
	{
		int cubesToSpawn = cubeToggleGroup.ActiveToggle.Amount;
		GameManager.StartGame(cubesToSpawn);
	}

	private void OnEnable()
	{
		cubeToggleGroup.OnToggleChanged += OnCubeToggleChanged;
		button.onClick.AddListener(OnButtonClicked);
		OnCubeToggleChanged(null, cubeToggleGroup.ActiveToggle);
	}
	private void OnDisable()
	{
		cubeToggleGroup.OnToggleChanged -= OnCubeToggleChanged;
		button.onClick.RemoveListener(OnButtonClicked);
	}
}
