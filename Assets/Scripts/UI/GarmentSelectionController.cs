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

	/// <summary>
	/// Raises the click button event.
	/// </summary>
	/// <param name="button">Button.</param>
	public void OnClickButton(EGarment button)
	{
		switch(button)
		{
			case EGarment.ONE:
				break;

			case EGarment.TWO:
				break;

			case EGarment.THREE:
				break;

			case EGarment.FOUR:
				break;
		}
	}


}
