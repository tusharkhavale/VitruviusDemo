using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour 
{
	private UIManager uiManager;
	private Animator anim;
	private GameObject maleAvatar;
	private GameObject femaleAvatar;

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
		maleAvatar = transform.Find ("MaleAvatar").gameObject;
		femaleAvatar = transform.Find ("FemaleAvatar").gameObject;
	}

	/// <summary>
	/// Updates top bar status.
	/// </summary>
	public void ShowTopBar(bool value)
	{
		anim.SetBool ("open", value);
	}

	/// <summary>
	/// Raises the click gender avatar event.
	/// </summary>
	public void OnClickGenderAvatar()
	{
		uiManager.ShowGenderSelection (true);
	}

	/// <summary>
	/// Sets the gneder avatar display topbar.
	/// </summary>
	public void SetGenderAvatar (EGender gender)
	{
		switch (gender) 
		{
			case EGender.MALE:
				maleAvatar.SetActive (true);
				femaleAvatar.SetActive (false);
				break;

			case EGender.FEMALE:
				maleAvatar.SetActive (false);
				femaleAvatar.SetActive (true);
				break;
		}
	}
}
