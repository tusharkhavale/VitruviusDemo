using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	string testPathPant = "Models/pants/pants";
	string testPathShirt = "Models/tshirt/tshirt";


	private GameObject hangerFemale;
	private GameObject hangerMale;
	private GameController gameController;
	private Transform hanger;

	private static ResourceManager instance;
	public static ResourceManager GetInstance()
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
	/// Loads the references from hierarchy.
	/// </summary>
	private void LoadReferences()
	{
		gameController = GameController.GetInstance ();
		hangerFemale = transform.Find ("HangerFemale").gameObject;
		hangerMale = transform.Find ("HangerMale").gameObject;
	}

	/// <summary>
	/// Shows the hanger.
	/// </summary>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void ShowHanger(bool value)
	{
		if (gameController.Gender == EGender.MALE)
			ShowHangerMale (value);
		else
			ShowHangerFemale (value);
	}

	/// <summary>
	/// Shows the male garments.
	/// </summary>
	private void ShowHangerMale(bool value)
	{
		hanger = hangerMale.transform;
		hangerMale.SetActive(value);
		hangerMale.transform.GetComponent<Animator> ().enabled = value;
		ShowAllGarments (value);
	}

	/// <summary>
	/// Shows the female garments.
	/// </summary>
	private void ShowHangerFemale(bool value)
	{
		hanger = hangerFemale.transform;
		hangerFemale.SetActive(value);
		hangerFemale.transform.GetComponent<Animator> ().enabled = value;
		ShowAllGarments (value);
	}

	/// <summary>
	/// Raises the garment selection event.
	/// </summary>
	/// <param name="button">Button.</param>
	public void OnGarmentSelection(EGarment button)
	{
		Transform cloth = hanger.Find (button.ToString ());
		Cloth c = cloth.GetComponentInChildren<Cloth> ();
		if (c != null)
			c.enabled = false;
		AvatarCloth avatarCloth = cloth.GetComponent<TShirt> ();
		if (avatarCloth == null)
			avatarCloth = cloth.GetComponent<Pants> ();
		if (avatarCloth == null)
			avatarCloth = cloth.GetComponent<LongSleeve> ();
		if (avatarCloth == null)
			avatarCloth = cloth.GetComponent<FullBody> ();

		FittingRoomSample.GetInstance ().SetSelectedCloth (avatarCloth);
		HideUnselectedGarments (button.ToString ());
	}

	/// <summary>
	/// Hides the unselected garments on the hanger.
	/// </summary>
	/// <param name="garment">Garment.</param>
	private void HideUnselectedGarments(string garment)
	{
		hanger.GetComponent<Animator> ().enabled = false;
		for (int i = 0; i < hanger.childCount; i++) 
		{
			if (hanger.transform.GetChild (i).name != garment)
				hanger.transform.GetChild (i).gameObject.SetActive(false);
		}
	}

	/// <summary>
	/// Shows all garments on the hanger.
	/// </summary>
	private void ShowAllGarments(bool value)
	{
		for (int i = 0; i < hanger.childCount; i++) 
		{
			hanger.GetChild (i).gameObject.SetActive(value);
		}
	}

#region temp loading assets

	void LoadPant(string path)
	{
		Object o = Resources.Load(path);
		GameObject go = Instantiate (o) as GameObject;
		go.AddComponent<Pants> ();

		//		Texture jean = Resources.Load<Texture> ("Models/pants/Textures/jean_diffuse_black");
		//		go.GetComponentInChildren<SkinnedMeshRenderer> ().material.mainTexture = jean;
	}

	void LoadShirt(string path)
	{
		Object o = Resources.Load(path);
		GameObject go = Instantiate (o) as GameObject;
		go.AddComponent<TShirt> ();	
	}

#endregion
}
