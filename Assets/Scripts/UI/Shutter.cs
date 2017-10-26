using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour {

	private Transform[] shutter;
	private UIManager uiManager;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadReferences ();
	}


	/// <summary>
	/// Loads shutters from Hierarchy.
	/// </summary>
	private void LoadReferences()
	{
		uiManager = transform.GetComponentInParent<UIManager> ();
		shutter = new Transform[transform.childCount];
		for (int i = 0; i < shutter.Length; i++)
			shutter [i] = transform.GetChild (i);
	}


	/// <summary>
	/// Updates the shutter position.
	/// </summary>
	public void UpdateShutter(bool value)
	{
		for (int i = 0; i < shutter.Length; i++) 
		{
			shutter [i].GetComponent<Animator> ().SetBool ("open", value);
		}
	}

	/// <summary>
	/// Raises the animation end event.
	/// </summary>
	public void OnAnimationEnd()
	{
//		uiManager.ShowGenderSelection (true);
		uiManager.ShowStartPage(true);
	}
}
