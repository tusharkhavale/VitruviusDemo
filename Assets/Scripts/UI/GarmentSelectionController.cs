using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarmentSelectionController : MonoBehaviour {

	/// <summary>
	/// Enables the animator component.
	/// </summary>
	public void ShowGarmentSelection()
	{
		transform.GetComponent<Animator> ().enabled = true;
	}
}
