﻿using UnityEngine;
using System;

public class GenderSelection : KinectButton
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
		EGender gender = (EGender)Enum.Parse (typeof(EGender), gameObject.name);
		GameController.GetInstance().OnGenderSelection (gender);
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
