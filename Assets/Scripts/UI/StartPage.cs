using UnityEngine;
using UnityEngine.UI;
using LightBuzz.Vitruvius;
using Windows.Kinect;

public class StartPage: VitruviusSample {

	BodyWrapper body;
	GestureController gestureController;

	protected override void Awake()
	{
		base.Awake();

		gestureController = new GestureController();
		gestureController.GestureRecognized += GestureRecognized;
		gestureController.Start();
	}

	void OnDisable()
	{
//		base.OnApplicationQuit();

		if (gestureController != null)
		{
			gestureController.Stop();
			gestureController.GestureRecognized -= GestureRecognized;
			gestureController = null;
		}
	}

	void Update()
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

		UpdateBodyFrame();

		if (body != null)
		{
			gestureController.Update(body);
		}
	}

	protected override void OnBodyFrameReceived(BodyFrame frame)
	{
		Body body = frame.Bodies().Closest();

		if (body != null)
		{
			if (this.body == null)
			{
				this.body = BodyWrapper.Create(body, CoordinateMapper, visualization);
			}
			else
			{
				this.body.Set(body, CoordinateMapper, visualization);
			}
		}
		else if (this.body != null)
		{
			this.body = null;
		}
	}

	void GestureRecognized(object sender, GestureEventArgs e)
	{
		//		gestureText.text = "Gesture: <b>" + e.GestureType.ToString() + "</b>";
		StartGestureRecognized();
	}

	/// <summary>
	/// Users the gesture recognized.
	/// </summary>
	public void StartGestureRecognized()
	{
		GameController.GetInstance ().OnStartGestureRecognized ();
	}

}