using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CubeToggleGroup : MonoBehaviour
{
	[SerializeField] private ToggleGroup toggleGroup;
	private List<CubeToggle> toggles;
	public CubeToggle ActiveToggle { get; private set; }
	public event Action<CubeToggle, CubeToggle> OnToggleChanged;

	private void InvokeOnToggleChanged(CubeToggle toggle, bool state)
	{
		CubeToggle previousActiveToggle = ActiveToggle;
		ActiveToggle = toggles.FirstOrDefault(t => t.State);
		if (ActiveToggle == previousActiveToggle)
			return;

		OnToggleChanged?.Invoke(previousActiveToggle, ActiveToggle);
	}

	private void Awake()
	{
		toggles = new List<CubeToggle>();

		// Cache settings
		int[] amounts = Settings.UI.CubeToggleAmounts;
		Color[] colors = Settings.UI.CubeToggleIconColors;
		CubeToggle prefab = Settings.UI.CubeTogglePrefab;

		// Instantiate and initialize new toggles
		for (int i = 0; i < amounts.Length; i++)
		{
			var newToggle = Instantiate(prefab, transform);
			newToggle.Amount = amounts[i];
			newToggle.ToggleGroup = toggleGroup;
			if (i < colors.Length)
				newToggle.CubeColor = colors[i];

			newToggle.AddCallbackOnStateChanged(state => InvokeOnToggleChanged(newToggle, state));
			toggles.Add(newToggle);
		}
	}
	private void OnEnable()
	{
		if (ActiveToggle != null)
			ActiveToggle.State = false;
	}
}
