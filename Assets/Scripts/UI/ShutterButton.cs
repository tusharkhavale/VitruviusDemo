﻿using UnityEngine;

public class ShutterButton : KinectButton
{
	/// <summary>
	/// Raises the hover exit event.
	/// </summary>
	protected override void OnHoverExit()
	{
		KinectUI.Instance.HideGauge(cursorInfo);
	}

	/// <summary>
	/// Raises the hover stay event.
	/// </summary>
	protected override void OnHoverStay()
	{
		KinectUI.Instance.ValidateGauge(cursorInfo, OnGaugeEnd);
	}

	/// <summary>
	/// Raises the gauge end event.
	/// </summary>
	void OnGaugeEnd()
	{
		GameController.GetInstance ().OnShutterOpen ();
	}

	public void OnMouseDown()
	{
		OnGaugeEnd ();
	}
		
}
