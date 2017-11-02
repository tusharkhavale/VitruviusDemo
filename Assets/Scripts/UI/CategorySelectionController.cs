using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategorySelectionController : MonoBehaviour {

	public void ShowCategorySelection()
	{
		transform.GetComponent<Animator> ().enabled = true;
	}
}
