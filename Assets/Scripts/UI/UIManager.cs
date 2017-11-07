using System;
using UnityEngine;

public class UIManager : MonoBehaviour {

	private static UIManager instance;
	private Shutter shutter;
	private ShutterButton btnShutter;
	private TopBar topBar;
	private GenderSelectionController genderSelection;
	private CategorySelectionController categorySelector;
	private GarmentSelectionController garmentSelectionController;
	private SpriteManager spriteManager;
	private GameObject startPage;

	/// <summary>
	/// Returns the instance.
	/// </summary>
	/// <returns>The instance.</returns>
	public static UIManager GetInstance()
	{
		if (instance != null) 
		{
			return instance;
		}
		return null;
	}

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		instance = this;
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadReferences ();
	}

	/// <summary>
	/// Loads the references from Hierarchy.
	/// </summary>
	void LoadReferences()
	{
		shutter = transform.Find ("Shutter").GetComponent<Shutter> ();
		btnShutter = transform.Find ("ShutterButton").GetComponent<ShutterButton> ();
		topBar = transform.Find ("TopBar").GetComponent<TopBar> ();
		genderSelection = transform.Find ("GenderSelection").gameObject.GetComponent<GenderSelectionController>();
		categorySelector = transform.Find ("CategorySelector").gameObject.GetComponent<CategorySelectionController>();
		spriteManager = transform.GetComponent<SpriteManager> ();
		startPage = transform.Find ("StartPage").gameObject;
		garmentSelectionController = transform.Find ("GarmentSelector").GetComponent<GarmentSelectionController> ();
	}

	/// <summary>
	/// Updates shutter position.
	/// </summary>
	public void UpdateShutter(bool value)
	{
		if (shutter != null)
			shutter.UpdateShutter (value);

		if (btnShutter != null)
			btnShutter.gameObject.SetActive (!value);
	}

	/// <summary>
	/// Updates the top bar status
	/// </summary>
	public void ShowTopBar(bool value)
	{
		if (topBar != null)
			topBar.ShowTopBar (value);
	}

	/// <summary>
	/// Raises the gender selection event.
	/// </summary>
	/// <param name="gender">Gender.</param>
	public void OnGenderSelection(EGender gender)
	{
		ShowGenderSelection (false);
		topBar.SetGenderAvatar (gender);
	}

	/// <summary>
	/// Shows the gender selection.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void ShowGenderSelection(bool value)
	{
		genderSelection.gameObject.SetActive (value);
		genderSelection.ShowGenderSelection ();
	}

	/// <summary>
	/// Raises the category selection event.
	/// </summary>
	/// <param name="category">Category.</param>
	public void OnCategorySelection(ECategory category)
	{
		ShowCategorySelector (false);
		topBar.SetCategoryDisplay (category);
	}

	/// <summary>
	/// Shows the category selector.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void ShowCategorySelector(bool value)
	{
		categorySelector.gameObject.SetActive (value);
		if(value)
			categorySelector.ShowCategorySelection ();
	}

	/// <summary>
	/// Gets the sprite.
	/// </summary>
	/// <returns>The sprite.</returns>
	/// <param name="category">Category.</param>
	public Sprite GetSprite(ECategory category)
	{
		return spriteManager.GetSprite (category);
	}


	/// <summary>
	/// Shows the garment selection.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void ShowGarmentSelection(bool value)
	{
		garmentSelectionController.gameObject.SetActive (value);
		if(value)
			garmentSelectionController.ShowGarmentSelection ();
	}

	/// <summary>
	/// Raises the garment selection event.
	/// </summary>
	/// <param name="garment">Garment.</param>
	public void OnGarmentSelection(EGarment garment)
	{
//		garmentSelectionController.OnClickButton (garment);
		ShowGarmentSelection(false);
		topBar.ShowBackButton (true);
	}


	/// <summary>
	/// Shows the StartPage.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void ShowStartPage(bool value)
	{
		startPage.SetActive (value);
	}

	/// <summary>
	/// Raises the start gesture recognized event.
	/// </summary>
	public void OnStartGestureRecognized()
	{
		ShowStartPage (false);
		ShowGenderSelection (true);
		ShowCategorySelector (false);
	}

	/// <summary>
	/// Raises the back button event.
	/// </summary>
	public void OnBackButton()
	{
		ShowGarmentSelection (true);
	}


	public bool open;
	public bool close;
	void Update()
	{
		if (open) 
		{
			open = false;
			UpdateShutter (true);
			ShowTopBar (true);
		}

		if (close) 
		{
			close = false;
			ShowTopBar (false);
			UpdateShutter (false);
		}
	}

}
