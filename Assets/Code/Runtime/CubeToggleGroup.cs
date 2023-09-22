using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class CubeToggleGroup : MonoBehaviour
{
	[SerializeField] CubeToggle cubeTogglePrefab;
	private List<CubeToggle> toggles;
	public event Action<CubeToggle, CubeToggle> OnToggleChanged;
	public CubeToggle ActiveToggle { get; private set; }


	private void Awake()
	{
		// Destroy placeholder toggles
		for (int i = transform.childCount - 1; i >= 0; i--)
			DestroyImmediate(transform.GetChild(i).gameObject);

		toggles = new List<CubeToggle>();
		ToggleGroup toggleGroup = GetComponent<ToggleGroup>();
		int[] amounts = Settings.UI.CubeToggleAmounts;
		Color[] colors = Settings.UI.CubeToggleIconColors;

		// Instantiate and initialize new toggles
		for (int i = 0; i < amounts.Length; i++)
		{
			var newToggle = Instantiate(cubeTogglePrefab, transform);
			newToggle.Amount = amounts[i];
			newToggle.ToggleGroup = toggleGroup;
			if (i < colors.Length)
				newToggle.CubeColor = colors[i];

			newToggle.AddCallbackOnStateChanged(state => InvokeOnToggleChanged(newToggle, state));
			toggles.Add(newToggle);
		}
	}
	private void InvokeOnToggleChanged(CubeToggle toggle, bool state)
	{
		CubeToggle previousActiveToggle = ActiveToggle;
		ActiveToggle = toggles.FirstOrDefault(t => t.State);
		if (ActiveToggle == previousActiveToggle)
			return;

		OnToggleChanged?.Invoke(previousActiveToggle, ActiveToggle);
	}
}
