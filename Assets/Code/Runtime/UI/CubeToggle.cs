using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CubeToggle : MonoBehaviour
{
	[SerializeField] private Toggle toggle;
	[SerializeField] private Image image;
	[SerializeField] private Image icon;
	[SerializeField] private TMP_Text text;
	[SerializeField] private Sprite selectedSprite;

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

	private void AnimateToggle(bool state)
	{
		Vector3 targetScale = Vector3.one;
		if (state)
			targetScale *= Settings.UI.SelectedToggleScale;
		transform.localScale = targetScale;

		image.sprite = state ? selectedSprite : originalSprite;
	}

	private void Awake()
	{
		originalSprite = image.sprite;
		AddCallbackOnStateChanged(AnimateToggle);
	}
}
