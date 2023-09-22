using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
	[SerializeField] CubeToggleGroup cubeToggleGroup;
	[SerializeField] Image icon;
	private Button button;


	private void Awake()
	{		
		button = GetComponent<Button>();		
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
	}

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
}
