using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ETopbarState
{
	GENDER_SELECTION,
	CATEGORY_SELECTION,
	GARMENT_SELECTION,
	GARMENT_TRIAL
}

public class TopBar : MonoBehaviour 
{
	private UIManager uiManager;
	private Animator anim;
	private GameObject maleAvatar;
	private GameObject femaleAvatar;
	private Transform category;
	private GameObject back;
	private GameObject scale;
	private ETopbarState state;


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
		back = transform.Find ("Back").gameObject;
		scale = transform.Find ("Scale").gameObject;
	}

	/// <summary>
	/// Updates top bar status.
	/// </summary>
	public void ShowTopBar(bool value)
	{
		HideTopBarButtons ();
		anim.SetBool ("open", value);
	}

#region Avatar icon


	/// <summary>
	/// Raises the click gender avatar event.
	/// </summary>
	public void OnClickGenderAvatar()
	{
		uiManager.ShowGenderSelection (true);
		uiManager.ShowGarmentSelection (false);

		FittingRoomSample.GetInstance ().ResetSelectedCloth ();
		ResourceManager.GetInstance ().ShowHanger (false);
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
				maleAvatar.GetComponent<Animator> ().enabled = true;
				break;

			case EGender.FEMALE:
				maleAvatar.SetActive (false);
				femaleAvatar.SetActive (true);
				femaleAvatar.GetComponent<Animator> ().enabled = true;
				break;
		}

	}

	/// <summary>
	/// Hides the gender avatar.
	/// </summary>
	/// <returns>The gender avatar.</returns>
	private void HideTopBarButtons()
	{
		maleAvatar.GetComponent<Animator> ().enabled = false;
		femaleAvatar.GetComponent<Animator> ().enabled = false;
		maleAvatar.SetActive (false);
		femaleAvatar.SetActive (false);
		category.gameObject.SetActive (false); 
		ShowBackButton (false);
		ShowScaleButton (false);
	}

	/// <summary>
	/// Hides the top bar buttons.
	/// </summary>
	public void ShowTopBarButtons(bool value)
	{
		if (GameController.GetInstance ().Gender == EGender.MALE) {
			maleAvatar.SetActive (value);
			maleAvatar.GetComponent<Animator> ().enabled = false;
		}
		else 
		{
			femaleAvatar.SetActive (value);
			femaleAvatar.GetComponent<Animator> ().enabled = false;
		}
			

		ShowBackButton (value);
		ShowScaleButton (value);
	}



	/// <summary>
	/// Raises the gender animation end event.
	/// </summary>
	public void OnGenderAnimationEnd()
	{
//		uiManager.ShowCategorySelector (true);
		GameController.GetInstance ().OnGenderSelectionAnimationEnd ();
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
		category.GetComponent<Animator> ().enabled = true;
	}

	/// <summary>
	/// Raises the category animation end event.
	/// </summary>
	public void OnCategoryAnimationEnd()
	{
//		GameController.GetInstance ().OnCategorySelectionAnimationEnd ();
	}
#endregion

	/// <summary>
	/// Raises the scale button event.
	/// </summary>
	public void OnScaleButton()
	{
//		HideTopBarButtons ();

		uiManager.ShowScale (true);
		HideTopBarButtons ();
		FittingRoomSample.GetInstance ().ShowTrialTextures (false);
	}

	/// <summary>
	/// Shows the scale button.
	/// </summary>
	public void ShowScaleButton(bool value)
	{
		scale.SetActive (value);
	}

	/// <summary>
	/// Shows the back button.
	/// </summary>
	public void ShowBackButton(bool value)
	{
		back.SetActive (value);
	}


	/// <summary>
	/// Hides last states gameobjects
	/// </summary>
	private void UpdatePreviousState(ETopbarState newState)
	{
		switch(state)
		{
			case ETopbarState.CATEGORY_SELECTION:
				uiManager.ShowCategorySelector (false);
				break;

			case ETopbarState.GARMENT_SELECTION:
				uiManager.ShowGarmentSelection (false);
				break;

			case ETopbarState.GARMENT_TRIAL:
				break;

			case ETopbarState.GENDER_SELECTION:
				uiManager.ShowGenderSelection (false);
				break;
		}

		state = newState;
	}

}
