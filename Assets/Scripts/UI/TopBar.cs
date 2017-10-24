using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour 
{
	private UIManager uiManager;
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
		uiManager = transform.GetComponentInParent<UIManager> ();
	}

	/// <summary>
	/// Updates top bar status.
	/// </summary>
	public void UpdateTopBar(bool value)
	{
		anim.SetBool ("open", value);
	}

}
