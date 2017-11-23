using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LightBuzz.Vitruvius;
using LightBuzz.Vitruvius.Avateering;
using Windows.Kinect;

public class FittingRoomSample : VitruviusSample
{
    #region Variables
	public float offsetX;
	public float defaultY = 180f;
	public float maxY = 205f;
	public float minY = 155f;
    BodyWrapper body;
	private AvatarCloth selectedCloth;
	public AvatarCloth trialCloth;
	public Texture[] trailTexture;
	public Camera secondaryCamera;

    public bool useGreenScreen = true;
	public GameObject greenScreenView;
    public GameObject trialTextures;
	private bool autoRunActivated;

	#endregion

	private static FittingRoomSample instance;
	public static FittingRoomSample GetInstance()
	{
		if (instance != null) 
		{
			return instance;
		}
		return null;
	}
    
	#region Delegates

	public delegate void BodyFrameReceived();
	public event BodyFrameReceived bodyFrameReceived;


	/// <summary>
	/// Adds the delegate.
	/// </summary>
	/// <param name="del">Del.</param>
	public void AddDelegate(BodyFrameReceived del)
	{
		bodyFrameReceived += del;
	}

    #endregion

    #region Reserved methods // Awake - OnApplicationQuit - Update - OnGUI

    protected override void Awake()
    {
        base.Awake();
		instance = this;
        Avateering.Enable();
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();

        Avateering.Disable();
    }

    void Update()
	{
		if (useGreenScreen) {
			if (colorFrameReader != null && depthFrameReader != null && bodyIndexFrameReader != null) {
				using (ColorFrame colorFrame = colorFrameReader.AcquireLatestFrame ())
				using (DepthFrame depthFrame = depthFrameReader.AcquireLatestFrame ())
				using (BodyIndexFrame bodyIndexFrame = bodyIndexFrameReader.AcquireLatestFrame ()) {
					if (colorFrame != null && depthFrame != null && bodyIndexFrame != null) {
						frameView.FrameTexture = colorFrame.GreenScreen (depthFrame, bodyIndexFrame);
					}
				}
			}
		} else {
			switch (visualization) {
			case Visualization.Color:
				UpdateColorFrame ();
				break;
			case Visualization.Depth:
				UpdateDepthFrame ();
				break;
			default:
				UpdateInfraredFrame ();
				break;
			}
		}

		UpdateBodyFrame ();

		if (useGreenScreen) {
			if (!greenScreenView.activeSelf) {
				greenScreenView.SetActive (true);
			}
		} else if (greenScreenView.activeSelf) {
			greenScreenView.SetActive (false);
		}

		if (body != null)
		{
				if (selectedCloth != null) 
				{
					Windows.Kinect.Vector4 spineOrientation = body.JointOrientations [JointType.SpineBase].Orientation;
					float spineY = spineOrientation.ToQuaternion ().eulerAngles.y;
						
					//					Debug.Log ("Height : " + body.Height());
					//					Debug.Log ("Uppera Height : " + body.UpperHeight());
						
					// Restricting the tracking beyond this angles n vertical axis
					if (spineY < minY || spineY > maxY)
						selectedCloth.updateJoints = false;
					else 
					{
						// X offset calculation based on Y-axis pivot rotation
						offsetX = -(defaultY - spineY) / 100;
						selectedCloth.updateJoints = true;
					}
							
						
					AvatarCloth cloth = selectedCloth;
						
					Avateering.Update (cloth, body);
						
					Vector2 position = body.Joints [cloth.Pivot].Position.ToPoint (useGreenScreen ? Visualization.Depth : visualization, CoordinateMapper);
						
					if (!float.IsInfinity (position.x) && !float.IsInfinity (position.y)) 
					{
						position = frameView.GetPositionOnFrame (position);
						// Adding x offset
						position = position + new Vector2 (offsetX, 0f);
						cloth.SetBonePosition (cloth.Pivot, position);
						
						float distance = cloth.JointInfos [(int)cloth.Pivot].RawPosition.z;
						
						if (distance != 0 ) 
						{
							cloth.Body.transform.localScale = cloth.ScaleOrigin * (cloth.colorScaleFactor / distance) * frameView.ViewScale;
							float y = cloth.Body.transform.position.y;
						}
					}
				}
		} 
		else 
		{
				if (selectedCloth )
					selectedCloth.Reset ();
		}

	}

    #endregion

    #region OnBodyFrameReceived

    protected override void OnBodyFrameReceived(BodyFrame frame)
    {
		
        Body body = frame.Bodies().Closest();

        if (body != null)
        {
			if (bodyFrameReceived != null)
				bodyFrameReceived ();

            if (this.body == null)
            {
                this.body = BodyWrapper.Create(body, CoordinateMapper, useGreenScreen ? Visualization.Depth : visualization);
            }
            else
            {
                this.body.Set(body, CoordinateMapper, useGreenScreen ? Visualization.Depth : visualization);
            }
        }
        else if (this.body != null)
        {
            this.body = null;
        }
    }

    #endregion

	public void OnScale(EScale value)
	{
		if (selectedCloth == null)
			return;

		if (value == EScale.INCREMENT) 
		{
			selectedCloth.colorScaleFactor += 0.0005f;
		}
		else 
		{
			selectedCloth.colorScaleFactor -= 0.0005f;
		}
	}


	public void SetSelectedCloth( AvatarCloth cloth)
	{
		if (cloth == null)
			Debug.Log ("cloth is null");

			selectedCloth = cloth;
			selectedCloth.Initialize ();
			ShowTrialTextures (true);	
//			secondaryCamera.gameObject.SetActive (true);
	}

	public void ResetSelectedCloth()
	{
		//null check
		if (selectedCloth == null)
			return;

		AvatarCloth cloth = selectedCloth;
		selectedCloth = null;
		cloth.Reset ();
		cloth.Dispose ();
		StopAllCoroutines ();
		ShowTrialTextures (false);
//		secondaryCamera.gameObject.SetActive (true);
//		Cloth c = cloth.transform.GetComponentInChildren<Cloth> ();
//		if (cloth != null)
//			cloth.enabled = false;
	}

	public void SetTrialTexture(EGarment garment)
	{
		SkinnedMeshRenderer renderer = selectedCloth.transform.GetComponentInChildren<SkinnedMeshRenderer> ();
		renderer.material.mainTexture = trailTexture[(int)garment-1];
		ShowTrialTextures(true);	
	}

	public void ResetTrialTextures()
	{
		ResetSelectedCloth ();
		autoRunActivated = false;
		trialCloth.gameObject.SetActive (false);
	}

	public void AutorunTrialTextures()
	{
		if (!autoRunActivated) 
			StartCoroutine (Autorun ());
		else 
			StopAllCoroutines ();

		autoRunActivated = !autoRunActivated;
	}

	IEnumerator Autorun()
	{
		SkinnedMeshRenderer renderer = selectedCloth.transform.GetComponentInChildren<SkinnedMeshRenderer> ();
		int i = 0;
		while (true) 
		{
			renderer.material.mainTexture = trailTexture[(i % trailTexture.Length)];
				i++;
				yield return new WaitForSeconds (3f);
		}
	}

	public void ShowTrialTextures(bool value)
	{
		trialTextures.SetActive (value);
	}

}