using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminScreen : MonoBehaviour {

	private Button btnMirror;
	private Button btnSettings;
	private Button btnSync;
	private Button btnLogout;
	private UIController uiController;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Start()
	{
		LoadReferences ();
		AddButtonListners ();
	}

	/// <summary>
	/// Loads the resources.
	/// </summary>
	private void LoadReferences()
	{
		btnMirror = transform.Find ("MirrorBtn").GetComponent<Button> ();
		btnSettings = transform.Find ("SettingsBtn").GetComponent<Button> ();
		btnSync = transform.Find ("SyncBtn").GetComponent<Button> ();
		btnLogout = transform.Find ("LogoutBtn").GetComponent<Button> ();
		uiController = transform.GetComponentInParent<UIController> ();
	}

	/// <summary>
	/// Adds the button listners.
	/// </summary>
	private void AddButtonListners()
	{
		btnMirror.onClick.AddListener (this.OnClickMirror);
		btnSync.onClick.AddListener (this.OnClickSync);
		btnSettings.onClick.AddListener (this.OnClickSettings);
		btnLogout.onClick.AddListener (this.OnClickLogout);
	}

#region button callback functions

	/// <summary>
	/// Raises the click mirror event.
	/// </summary>
	private void OnClickMirror()
	{
		uiController.OnClickMirror();
	}

	/// <summary>
	/// Raises the click sync event.
	/// </summary>
	private void OnClickSync()
	{
		uiController.OnClickSync();
	}

	/// <summary>
	/// Raises the click settings event.
	/// </summary>
	private void OnClickSettings()
	{
		uiController.OnClickSettings();
	}

	/// <summary>
	/// Raises the click logout event.
	/// </summary>
	private void OnClickLogout()
	{
		uiController.OnClickLogout ();
	}

#endregion
}
