using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncController : MonoBehaviour {

	MainController mainController;

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
	private void LoadReferences()
	{
		mainController = transform.GetComponentInParent<MainController> ();
	}

	/// <summary>
	/// Syncs the data.
	/// </summary>
	public void SyncData()
	{
		StartCoroutine (GetConfigFile ());
	}

	IEnumerator GetConfigFile()
	{
		yield return new WaitForSeconds (2f);

		mainController.uiController.SetSyncDescriptionText ("Downloading config file complete");

		yield return new WaitForSeconds (2f);

		mainController.uiController.SetSyncDescriptionText ("Downloading assets");

		yield return new WaitForSeconds (4f);

		mainController.uiController.SetSyncDescriptionText ("Downloading assets complete");

		yield return new WaitForSeconds (2f);

		mainController.uiController.SetSyncDescriptionText ("Sync complete");

		yield return new WaitForSeconds (2f);

		mainController.OnDataSync ();
	}
}
