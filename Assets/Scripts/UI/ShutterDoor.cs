using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterDoor : MonoBehaviour {

	public void OnAnimationEnd()
	{
		transform.GetComponentInParent<Shutter> ().OnAnimationEnd ();
	}
}
