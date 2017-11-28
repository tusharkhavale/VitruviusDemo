using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	private static MainController instance;
	public UIController uiController;
	private SyncController syncController;


	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <returns>The instance.</returns>
	public static MainController GetInstance()
	{
		if (instance != null) 
		{
			return instance;
		}
		return null;
	}

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		instance = this;
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadReferences ();
		uiController.TransitionToState (UIState.LOGIN_SCREEN);

	}

	/// <summary>
	/// Loads the references.
	/// </summary>
	private void LoadReferences()
	{
		syncController = transform.Find ("SyncController").GetComponent<SyncController> ();
	}

	/// <summary>
	/// Syncs the data from server.
	/// </summary>
	public void SyncData()
	{
		syncController.SyncData ();
	}

	/// <summary>
	/// Raises the data sync event.
	/// </summary>
	public void OnDataSync()
	{
		uiController.HidePopUp (PopUpState.SYNC);
	}

}
