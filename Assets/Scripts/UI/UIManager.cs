using System;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private static UIManager instance;
	private Shutter shutter;
	private ShutterButton btnShutter;
	private TopBar topBar;

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
	}

	/// <summary>
	/// Updates shutter position.
	/// </summary>
	public void UpdateShutter(bool value)
	{
		if (shutter != null)
			shutter.UpdateShutter (value);
	}

	/// <summary>
	/// Updates the top bar status
	/// </summary>
	public void UpdateTopBar(bool value)
	{
		if (topBar != null)
			topBar.UpdateTopBar (value);
	}

	/// <summary>
	/// Updates the shutter button state.
	/// </summary>
	public void UpdateShutterButton(bool value)
	{
		if (btnShutter != null)
			btnShutter.gameObject.SetActive (value);
	}


	public bool open;
	public bool close;
	void Update()
	{
		if (open) 
		{
			open = false;
			UpdateShutter (true);
			UpdateShutterButton (false);
			UpdateTopBar (true);
		}

		if (close) 
		{
			close = false;
			UpdateTopBar (false);
			UpdateShutter (false);
			UpdateShutterButton (true);
		}
	}


	public void OnHoverButtonClicked(string button)
	{
		
	}
}
