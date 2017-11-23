using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private static GameController instance;
	private UIManager uiManager; 
	private ResourceManager resourceManager;
	private FittingRoomSample fittingRoomSample;
	private bool shutterState;
	private EGender currentGender;



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
	/// Gets or sets the gender.
	/// </summary>
	/// <value>The gender.</value>
	public EGender Gender
	{
		get{return currentGender;}
		set{currentGender = value;}
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
		fittingRoomSample = FittingRoomSample.GetInstance ();
		fittingRoomSample.AddDelegate (this.OnBodyFrameReceived);
	}

	/// <summary>
	/// Raises the body frame received event.
	/// </summary>
	public void OnBodyFrameReceived()
	{
		if (!shutterState) 
		{
			shutterState = true;
			OnShutterOpen ();
		}
	}

	/// <summary>
	/// Raises the shutter open event.
	/// </summary>
	public void OnShutterOpen()
	{
		uiManager.UpdateShutter (true);
//		uiManager.ShowTopBar (true);
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
		Gender = gender;
		uiManager.OnGenderSelection (gender);
	}

	/// <summary>
	/// Raises the garment selection event.
	/// </summary>
	/// <param name="button">Button.</param>
	public void OnGarmentSelection(EGarment button)
	{
//		resourceManager.ShowGarments (false);
		resourceManager.OnGarmentSelection (button);
		uiManager.OnGarmentSelection (button);

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
	/// Raises the scale event.
	/// </summary>
	/// <param name="value">Value.</param>
	public void OnScale(EScale value)
	{
		fittingRoomSample.OnScale (value);
	}

	/// <summary>
	/// Raises the category selection animation end event.
	/// </summary>
	public void OnGenderSelectionAnimationEnd()
	{
		uiManager.ShowGarmentSelection (true);
		resourceManager.ShowHanger (true);
	}

	/// <summary>
	/// Raises the back button event.
	/// </summary>
	public void OnBackButton()
	{
		fittingRoomSample.ResetSelectedCloth ();
		resourceManager.ShowHanger (true);
		uiManager.OnBackButton ();
	}
}
