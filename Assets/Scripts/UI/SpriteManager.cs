using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

	private object[] categorySprites;

	void Start()
	{
		LoadSprites ();
	}

	public void LoadSprites()
	{
		categorySprites = Resources.LoadAll<Sprite> ("Sprites/ClothIcons");
	}

	public Sprite GetSprite(ECategory category)
	{
		return (Sprite)categorySprites [(int)category];
	}

}
