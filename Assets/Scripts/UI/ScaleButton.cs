using UnityEngine;
using System;

public class ScaleButton : KinectButton
{
	private EScale button;
	private Transform bg;

	void Start()
	{
		button = (EScale)Enum.Parse (typeof(EScale), gameObject.name);
		bg = transform.Find ("Bg");
	}

	/// <summary>
	/// Raises the hover exit event.
	/// </summary>
	protected override void OnHoverExit()
	{
		KinectUI.Instance.HideGauge(cursorInfo);
		transform.localScale = Vector3.one;
	}

	/// <summary>
	/// Raises the hover stay event.
	/// </summary>
	protected override void OnHoverStay()
	{
		GameController.GetInstance ().OnScale (button);
		transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
		bg.Rotate (Vector3.forward, 5f);
	}

	/// <summary>
	/// Raises the gauge end event.
	/// </summary>
	void OnGaugeEnd()
	{
		
	}

	/// <summary>
	/// Editor purpose
	/// Raises the mouse down event.
	/// </summary>
	public void OnMouseDown()
	{
		OnGaugeEnd ();
	}

}
