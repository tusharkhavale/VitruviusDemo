using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryScroller : KinectButton
{
	private Transform maleSelector;
	private Transform femaleSelector;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadReferences ();
	}

	/// <summary>
	/// Loads the references.
	/// </summary>
	/// <returns>The references.</returns>
	private void LoadReferences()
	{
		maleSelector = transform.Find ("MaleSelector");
		femaleSelector = transform.Find ("FemaleSelector");
	}


	/// <summary>
	/// Raises the dragging event.
	/// Rotate the clothes selector
	/// </summary>
	protected override void OnDragging()
	{
		//		listParent.position += new Vector3(cursorInfo.Direction.x, 0, 0);
		maleSelector.Rotate(0,cursorInfo.Direction.x, 0);
		femaleSelector.Rotate(0,cursorInfo.Direction.x, 0);
	}

	protected override void OnOutsideDragging()
	{
		OnDragging();
	}
}
