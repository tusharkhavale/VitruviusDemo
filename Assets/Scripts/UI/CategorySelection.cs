using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategorySelection : KinectButton
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
		ECategory category = (ECategory)System.Enum.Parse (typeof(ECategory), gameObject.name);
		GameController.GetInstance ().OnCategorySelection (category);
	}

	public void OnMouseDown()
	{
		OnGaugeEnd ();
	}

}
