using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterDoor : MonoBehaviour {

	/// <summary>
	/// Raises the animation end event.
	/// </summary>
	public void OnAnimationEnd()
	{
		transform.GetComponentInParent<Shutter> ().OnShutterOpneAnimationEnd ();
	}
}
