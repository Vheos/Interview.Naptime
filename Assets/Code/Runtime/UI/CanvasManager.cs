using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
	[SerializeField] private Canvas canvas;
	[SerializeField] private Canvas startMenuCanvas;
	[SerializeField] private Canvas gameOverCanvas;
	

	public bool IsVisible
	{
		get => gameObject.activeSelf;
		set => gameObject.SetActive(value);
	}
	private IEnumerable<Canvas> AllCanvases
	{
		get
		{
			yield return startMenuCanvas;
			yield return gameOverCanvas;
		}
	}

	public void ChangeScreen(UIScreen screen)
	{
		var visibleCanvas = screen switch
		{
			UIScreen.StartMenu => startMenuCanvas,
			UIScreen.GameOver => gameOverCanvas,
			_ => null,
		};

		if (visibleCanvas == null)
		{
			IsVisible = false;
			return;
		}

		IsVisible = true;
		foreach (var subCanvas in AllCanvases)
			subCanvas.gameObject.SetActive(subCanvas == visibleCanvas);
	}
}