using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour 
{
	private UIManager uiManager;
	private Animator anim;
	private GameObject maleAvatar;
	private GameObject femaleAvatar;
	private Transform category;

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
		category = transform.Find ("Category");
	}

	/// <summary>
	/// Updates top bar status.
	/// </summary>
	public void ShowTopBar(bool value)
	{
		HideGenderAvatar ();
		anim.SetBool ("open", value);
	}

#region Avatar icon


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

		maleAvatar.GetComponent<Animator> ().enabled = true;
		femaleAvatar.GetComponent<Animator> ().enabled = true;
	}

	/// <summary>
	/// Hides the gender avatar.
	/// </summary>
	/// <returns>The gender avatar.</returns>
	private void HideGenderAvatar()
	{
		maleAvatar.SetActive (false);
		femaleAvatar.SetActive (false);
		category.gameObject.SetActive (false); 
	}

	/// <summary>
	/// Raises the gender animation end event.
	/// </summary>
	public void OnGenderAnimationEnd()
	{
		uiManager.ShowCategorySelector (true);
	}

#endregion

#region Category Display

	/// <summary>
	/// Raises the click category event.
	/// </summary>
	public void OnClickCategory()
	{
		uiManager.ShowCategorySelector (true);
	}

	/// <summary>
	/// Sets the category display.
	/// </summary>
	/// <param name="value">Value.</param>
	public void SetCategoryDisplay(ECategory value)
	{
		category.gameObject.SetActive (false); 
		category.GetComponent<Image> ().sprite = uiManager.GetSprite (value);
		category.gameObject.SetActive (true); 
	}

	/// <summary>
	/// Raises the category animation end event.
	/// </summary>
	public void OnCategoryAnimationEnd()
	{
		
	}
#endregion
}
