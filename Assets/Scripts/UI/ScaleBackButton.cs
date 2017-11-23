using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackButton : KinectButton
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
		UIManager.GetInstance ().ShowScale (false);
		UIManager.GetInstance ().ShowTopBarButtons ();
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
