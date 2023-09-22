using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class CubeToggle : MonoBehaviour
{
	[SerializeField] Image icon;
	[SerializeField] TMP_Text text;
	private Toggle toggle;
	private int amount;

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(x => Debug.Log(x));
	}

	public ToggleGroup ToggleGroup
	{
		get => toggle.group;
		set => toggle.group = value;
	}
	public Color CubeColor
	{
		get => icon.color;
		set => icon.color = value;
	}
	public Color SharedTextShadowColor
	{
		get => text.fontSharedMaterial.GetColor(ShaderUtilities.ID_UnderlayColor);
		set => text.fontSharedMaterial.SetColor(ShaderUtilities.ID_UnderlayColor, value);
	}
	public int Amount
	{
		get => amount;
		set
		{
			amount = value;
			text.text = amount.ToString();
		}
	}

}
