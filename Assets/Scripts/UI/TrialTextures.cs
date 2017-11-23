using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrialTextures : MonoBehaviour {

	void Start()
	{
		transform.parent.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.gameObject.name == "Back")
			return;

		EGarment button = (EGarment)Enum.Parse (typeof(EGarment), coll.name);
		FittingRoomSample.GetInstance ().SetTrialTexture (button);
		coll.transform.GetComponent<DraggableElement>().ResetPosition();

	}

}
