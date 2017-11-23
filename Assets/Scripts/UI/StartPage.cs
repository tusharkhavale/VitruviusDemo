using UnityEngine;
using UnityEngine.UI;

public class StartPage : MonoBehaviour 
{
	public delegate void OnStart();
	public event OnStart onStart;

	/// <summary>
	/// Adds the start delegate.
	/// </summary>
	/// <param name="del">Del.</param>
	public void AddStartDelegate(OnStart del)
	{
		onStart += del;

	}

	/// <summary>
	/// Raises the animation end event.
	/// </summary>
	public void OnAnimationEnd()
	{
//		if (onStart != null)
//			onStart ();

		UIManager.GetInstance ().ShowStartPage (false);
		FittingRoomSample.GetInstance ().SetSelectedCloth (FittingRoomSample.GetInstance ().trialCloth);
		FittingRoomSample.GetInstance ().trialTextures.SetActive(true);
	}
}