using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
[RequireComponent(typeof(Image))]
public class CubeToggle : MonoBehaviour
{
	[SerializeField] Image icon;
	[SerializeField] TMP_Text text;
	[SerializeField] Sprite selectedSprite;

	private Toggle toggle;
	private Image image;
	private Sprite originalSprite;
	private int amount;

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
	public int Amount
	{
		get => amount;
		set
		{
			amount = value;
			text.text = amount.ToString();
		}
	}
	public bool State
	{
		get => toggle.isOn;
		set => toggle.isOn = value;
	}
	public void AddCallbackOnStateChanged(UnityAction<bool> callback)
		=> toggle.onValueChanged.AddListener(callback);

	private void OnToggle(bool state)
	{
		Vector3 targetScale = Vector3.one;
		if (state)
			targetScale *= Settings.UI.SelectedToggleScale;
		transform.localScale = targetScale;

		image.sprite = state ? selectedSprite : originalSprite;
	}

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		image = GetComponent<Image>();
		originalSprite = image.sprite;

		text.fontSharedMaterial.SetColor(ShaderUtilities.ID_UnderlayColor, Settings.UI.FontShadow);
		AddCallbackOnStateChanged(OnToggle);
	}
}
