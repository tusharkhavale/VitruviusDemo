using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	private UIState screenState; 
	private PopUpState popupState; 

	private MainController mainController;

	private GameObject loginScreen;
	private GameObject adminScreen;
	private GameObject syncPopup;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		LoadReferences ();
	}

	/// <summary>
	/// Loads the references.
	/// </summary>
	private void LoadReferences()
	{
		mainController = MainController.GetInstance ();
		loginScreen = transform.Find ("LoginScreen").gameObject;
		adminScreen = transform.Find ("AdminScreen").gameObject;
		syncPopup = transform.Find ("SyncPopup").gameObject;
	}


#region Screen Transition

	/// <summary>
	/// Transitions the UI state to.
	/// </summary>
	/// <param name="newState">New state.</param>
	public void TransitionToState(UIState newState)
	{
		UnloadState (screenState);
		LoadState (newState);
		screenState = newState;
	}

	/// <summary>
	/// Loads the state.
	/// </summary>
	/// <param name="state">State.</param>
	private void LoadState(UIState state)
	{
		switch (state) 
		{
			case UIState.LOGIN_SCREEN:
				loginScreen.SetActive (true);		
				break;

			case UIState.ADMIN_SCREEN:
				adminScreen.SetActive (true);
				break;
		}
	}

	/// <summary>
	/// Unloads the state.
	/// </summary>
	/// <param name="state">State.</param>
	private void UnloadState(UIState state)
	{
		switch (state) 
		{
			case UIState.LOGIN_SCREEN:
				loginScreen.SetActive (false);		
				break;

			case UIState.ADMIN_SCREEN:
				adminScreen.SetActive (false);
				break;
		}
	}

#endregion


#region Popup Transition
	public void ShowPopUp(PopUpState state)
	{
		switch (state) 
		{
			case PopUpState.SYNC:
				syncPopup.SetActive (true);
				break;
		}
	}

	public void HidePopUp(PopUpState state)
	{
		switch (state) 
		{
			case PopUpState.SYNC:
				syncPopup.SetActive (false);
				break;
		}
	}

#endregion


#region Button Callback functions

#region Login Screen
	/// <summary>
	/// Raises the click submit event.
	/// </summary>
	public void OnClickSubmit(string id, string password)
	{
		TransitionToState (UIState.ADMIN_SCREEN);
	}

#endregion


#region Admin Screen
	/// <summary>
	/// Raises the click mirror event.
	/// </summary>
	public void OnClickMirror()
	{

	}

	/// <summary>
	/// Raises the click sync event.
	/// </summary>
	public void OnClickSync()
	{
		ShowPopUp (PopUpState.SYNC);
		mainController.SyncData ();
	}

	/// <summary>
	/// Raises the click settings event.
	/// </summary>
	public void OnClickSettings()
	{
		System.Diagnostics.Process.Start ("explorer.exe");
	}

	/// <summary>
	/// Raises the click logout event.
	/// </summary>
	public void OnClickLogout()
	{
		TransitionToState (UIState.LOGIN_SCREEN);
	}

#endregion

#endregion


#region Display Text

	/// <summary>
	/// Sets the sync popup description text.
	/// </summary>
	public void SetSyncDescriptionText(string text)
	{
		syncPopup.transform.GetComponent<SyncPopup> ().SetDescriptionText (text);
	}

#endregion


}
