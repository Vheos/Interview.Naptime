using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private Image icon;

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