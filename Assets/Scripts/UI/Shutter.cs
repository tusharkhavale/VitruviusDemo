using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour {

	private Transform[] shutter;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadShutters ();
	}


	/// <summary>
	/// Loads shutters from Hierarchy.
	/// </summary>
	private void LoadShutters()
	{
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

}
