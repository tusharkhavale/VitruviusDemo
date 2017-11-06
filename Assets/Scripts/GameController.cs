﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private static GameController instance;
	private UIManager uiManager; 
	private ResourceManager resourceManager;

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
		resourceManager = ResourceManager.GetInstance ();
	}

	/// <summary>
	/// Raises the shutter open event.
	/// </summary>
	public void OnShutterOpen()
	{
		uiManager.UpdateShutter (true);
		uiManager.ShowTopBar (true);
	}

	/// <summary>
	/// Raises the shutter close event.
	/// </summary>
	public void OnShutterClose()
	{
			
	}

	/// <summary>
	/// Raises the gender selection event.
	/// </summary>
	/// <param name="gender">Gender.</param>
	public void OnGenderSelection(EGender gender)
	{
		uiManager.OnGenderSelection (gender);
	}

	/// <summary>
	/// Raises the garment selection event.
	/// </summary>
	/// <param name="button">Button.</param>
	public void OnGarmentSelection(EGarment button)
	{
		
	}

	/// <summary>
	/// Raises the category selection event.
	/// </summary>
	/// <param name="category">Category.</param>
	public void OnCategorySelection(ECategory category)
	{
		uiManager.OnCategorySelection (category);
	}

	/// <summary>
	/// Raises the category selection animation end event.
	/// </summary>
	public void OnCategorySelectionAnimationEnd()
	{
		uiManager.ShowGarmentSelection (true);
		resourceManager.ShowGarments (true);
	}

	/// <summary>
	/// Raises the start gesture recognized event.
	/// </summary>
	public void OnStartGestureRecognized()
	{
		uiManager.OnStartGestureRecognized ();
	}
}
