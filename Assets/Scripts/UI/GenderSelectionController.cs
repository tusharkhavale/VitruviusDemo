using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSelectionController : MonoBehaviour {

	private Transform maleSelector;
	private Transform femaleSelector;

	void Start()
	{
		maleSelector = transform.Find ("MALE");
		femaleSelector = transform.Find ("FEMALE");
	}

	public void ShowGenderSelection()
	{
		maleSelector.GetComponent<Animator> ().enabled = true;
		femaleSelector.GetComponent<Animator> ().enabled = true;
	}
}
