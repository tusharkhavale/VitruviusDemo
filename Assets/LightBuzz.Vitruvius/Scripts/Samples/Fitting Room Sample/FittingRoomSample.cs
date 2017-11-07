using UnityEngine;
using LightBuzz.Vitruvius;
using LightBuzz.Vitruvius.Avateering;
using Windows.Kinect;

public class FittingRoomSample : VitruviusSample
{
    #region Variables

    BodyWrapper body;
	AvatarCloth selectedCloth;

    public bool useGreenScreen = true;
    public GameObject greenScreenView;

	private static FittingRoomSample instance;
	public static FittingRoomSample GetInstance()
	{
		if (instance != null) 
		{
			return instance;
		}
		return null;
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
        if (useGreenScreen)
        {
            if (colorFrameReader != null && depthFrameReader != null && bodyIndexFrameReader != null)
            {
                using (ColorFrame colorFrame = colorFrameReader.AcquireLatestFrame())
                using (DepthFrame depthFrame = depthFrameReader.AcquireLatestFrame())
                using (BodyIndexFrame bodyIndexFrame = bodyIndexFrameReader.AcquireLatestFrame())
                {
                    if (colorFrame != null && depthFrame != null && bodyIndexFrame != null)
                    {
                        frameView.FrameTexture = colorFrame.GreenScreen(depthFrame, bodyIndexFrame);
                    }
                }
            }
        }
        else
        {
            switch (visualization)
            {
                case Visualization.Color:
                    UpdateColorFrame();
                    break;
                case Visualization.Depth:
                    UpdateDepthFrame();
                    break;
                default:
                    UpdateInfraredFrame();
                    break;
            }
        }

        UpdateBodyFrame();

        if (useGreenScreen)
        {
            if (!greenScreenView.activeSelf)
            {
                greenScreenView.SetActive(true);
            }
        }
        else if (greenScreenView.activeSelf)
        {
            greenScreenView.SetActive(false);
        }

        if (body != null)
        {
            {
				if (selectedCloth != null)
                {
					AvatarCloth cloth = selectedCloth;

                    Avateering.Update(cloth, body);

                    Vector2 position = body.Joints[cloth.Pivot].Position.ToPoint(useGreenScreen ? Visualization.Depth : visualization, CoordinateMapper);

                    if (!float.IsInfinity(position.x) && !float.IsInfinity(position.y))
                    {
                        position = frameView.GetPositionOnFrame(position);

                        cloth.SetBonePosition(cloth.Pivot, position);

                        float distance = cloth.JointInfos[(int)cloth.Pivot].RawPosition.z;
                        if (distance != 0)
                        {
                            cloth.Body.transform.localScale = cloth.ScaleOrigin * (cloth.colorScaleFactor / distance) * frameView.ViewScale;
                        }
                    }
                }
            }
        }
        else
        {
			if(selectedCloth)
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

	public void SetSelectedCloth( AvatarCloth cloth)
	{
		selectedCloth = cloth;
		selectedCloth.Initialize ();
	}

	public void ResetSelectedCloth()
	{
		AvatarCloth cloth = selectedCloth;
		selectedCloth = null;
		cloth.Reset ();
		cloth.Dispose ();
		cloth.transform.GetComponentInChildren<Cloth> ().enabled = true;
	}

}