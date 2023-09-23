using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CanvasManager : MonoBehaviour
{
	[SerializeField] private Canvas startMenuCanvas;
	[SerializeField] private Canvas gameOverCanvas;
	private Canvas canvas;

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

	private void Awake()
	{
		canvas = GetComponent<Canvas>();
	}
}