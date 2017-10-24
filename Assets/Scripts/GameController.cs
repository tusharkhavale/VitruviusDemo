using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private static GameController instance;
	private UIManager uiManager; 

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <returns>The instance.</returns>
	public static GameController GetInstance()
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
	/// Loads all references.
	/// </summary>
	/// <returns>The references.</returns>
	public void LoadReferences()
	{
		uiManager = UIManager.GetInstance ();
	}

	public void OnShutterOpen()
	{
		uiManager.UpdateShutter (true);
		uiManager.UpdateTopBar (true);
	}

	public void OnShutterClose()
	{
			
	}

	public void OnGenderSelection(EGender gender)
	{
		uiManager.OnGenderSelection (gender);
	}

}
