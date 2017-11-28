using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncPopup : MonoBehaviour {

	private Transform spinner;
	private Text txtDesc;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadReferences ();
		StartCoroutine (RotateSpinner());
	}

	/// <summary>
	/// Raises the enable event.
	/// Starts spinner rotation coroutine
	/// </summary>
	void OnEnable()
	{
		if(spinner != null)
			StartCoroutine (RotateSpinner());
	}

	/// <summary>
	/// Raises the disable event.
	/// Stops spinner rotation coroutine
	/// </summary>
	void OnDisable()
	{
		StopAllCoroutines ();
	}

	/// <summary>
	/// Loads the references.
	/// </summary>
	private void LoadReferences()
	{
		spinner = transform.Find ("Spinner");
		txtDesc = transform.Find ("DescTxt").GetComponent<Text> ();
	}

	/// <summary>
	/// Sets the description text.
	/// </summary>
	/// <param name="text">Text.</param>
	public void SetDescriptionText(string text)
	{
		txtDesc.text = text;
	}

	/// <summary>
	/// Rotates the spinner. 
	/// </summary>
	/// <returns>The spinner.</returns>
	IEnumerator RotateSpinner()
	{
		while (true) 
		{
			spinner.Rotate (-Vector3.forward * AppConstants.SPINNER_ANGLE);
			yield return new WaitForSeconds(AppConstants.SPINNER_DELAY);
		}
	}



}
