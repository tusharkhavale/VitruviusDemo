using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour 
{

	private Animator anim;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadComponents ();	
	}

	/// <summary>
	/// Loads components.
	/// </summary>
	private void LoadComponents()
	{
		anim = transform.GetComponent<Animator> ();
	}

	/// <summary>
	/// Updates top bar status.
	/// </summary>
	public void UpdateTopBar(bool value)
	{
		anim.SetBool ("open", value);
	}
}
