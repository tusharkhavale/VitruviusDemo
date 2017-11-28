using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutorunController : MonoBehaviour {


	private static AutorunController instance;
	private UIManager uiManager; 
	private ResourceManager resourceManager;
	private FittingRoomSample fittingRoomSample;
	private bool shutterState;


	public static AutorunController GetInstance()
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
		fittingRoomSample = FittingRoomSample.GetInstance ();
		fittingRoomSample.AddBodyFrameReceivedDelegate (this.OnBodyFrameReceived);
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
	}


}
