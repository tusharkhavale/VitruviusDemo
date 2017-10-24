using System;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private static UIManager instance;
	private Shutter shutter;
	private ShutterButton btnShutter;
	private TopBar topBar;
	private GameObject genderSelection;


	/// <summary>
	/// Returns the instance.
	/// </summary>
	/// <returns>The instance.</returns>
	public static UIManager GetInstance()
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
	}

	/// <summary>
	/// Loads the references from Hierarchy.
	/// </summary>
	void LoadReferences()
	{
		shutter = transform.Find ("Shutter").GetComponent<Shutter> ();
		btnShutter = transform.Find ("ShutterButton").GetComponent<ShutterButton> ();
		topBar = transform.Find ("TopBar").GetComponent<TopBar> ();
		genderSelection = transform.Find ("GenderSelection").gameObject;
	}

	/// <summary>
	/// Updates shutter position.
	/// </summary>
	public void UpdateShutter(bool value)
	{
		if (shutter != null)
			shutter.UpdateShutter (value);

		if (btnShutter != null)
			btnShutter.gameObject.SetActive (!value);
	}

	/// <summary>
	/// Updates the top bar status
	/// </summary>
	public void ShowTopBar(bool value)
	{
		if (topBar != null)
			topBar.ShowTopBar (value);
	}

	/// <summary>
	/// Raises the gender selection event.
	/// </summary>
	/// <param name="gender">Gender.</param>
	public void OnGenderSelection(EGender gender)
	{
		ShowGenderSelection (false);
		topBar.SetGenderAvatar (gender);
	}

	/// <summary>
	/// Shows the gender selection.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void ShowGenderSelection(bool value)
	{
		genderSelection.SetActive (value);
	}

	public bool open;
	public bool close;
	void Update()
	{
		if (open) 
		{
			open = false;
			UpdateShutter (true);
			ShowTopBar (true);
		}

		if (close) 
		{
			close = false;
			ShowTopBar (false);
			UpdateShutter (false);
		}
	}

}
