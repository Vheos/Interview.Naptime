using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class CubeToggleGroup : MonoBehaviour
{
	[SerializeField] CubeToggle cubeTogglePrefab;
	[SerializeField] UISettings settings;
	private List<CubeToggle> toggles;

	private void Awake()
	{
		// Destroy placeholder toggles
		for (int i = transform.childCount - 1; i >= 0; i--)
			DestroyImmediate(transform.GetChild(i).gameObject);

		toggles = new List<CubeToggle>();
		ToggleGroup toggleGroup = GetComponent<ToggleGroup>();
		int[] amounts = settings.CubeToggleAmounts;
		Color[] colors = settings.CubeToggleIconColors;

		// Instantiate and initialize new toggles
		for (int i = 0; i < amounts.Length; i++)
		{
			var newToggle = Instantiate(cubeTogglePrefab, transform);
			newToggle.Amount = amounts[i];
			newToggle.ToggleGroup = toggleGroup;
			if (i < colors.Length)
				newToggle.CubeColor = colors[i];

			toggles.Add(newToggle);
		}

		// Set shared properties
		if (toggles.Any())
			toggles.First().SharedTextShadowColor = settings.FontShadow;
	}
}
