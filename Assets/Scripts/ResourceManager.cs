using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	string testPathPant = "Models/pants/pants";
	string testPathShirt = "Models/tshirt/tshirt";

	private GameObject hanger;

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
		hanger = transform.Find ("Hanger").gameObject;
	}

	/// <summary>
	/// Shows the garments.
	/// </summary>
	public void ShowGarments(bool value)
	{
		hanger.SetActive(value);
	}

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

	/// <summary>
	/// Raises the garment selection event.
	/// </summary>
	/// <param name="button">Button.</param>
	public void OnGarmentSelection(EGarment button)
	{
		Transform cloth = hanger.transform.Find (button.ToString ());
		cloth.GetComponentInChildren<Cloth> ().enabled = false;
		AvatarCloth avatarCloth = cloth.GetComponent<TShirt> ();
		FittingRoomSample.GetInstance ().SetSelectedCloth (avatarCloth);
	}



}
