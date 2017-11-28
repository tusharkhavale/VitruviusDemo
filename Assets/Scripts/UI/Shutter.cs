using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Shutter : MonoBehaviour {

	private Transform[] shutter;
	private UIManager uiManager;

	//Video To Play [Assign from the Editor]
	public VideoClip videoToPlay;
	public VideoClip videoToPlay1;
	public VideoClip videoToPlay2;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadReferences ();
		Application.runInBackground = true;
//		StartCoroutine(playVideo(shutter[0],videoToPlay));
		StartCoroutine(playVideo(shutter[1],videoToPlay1));
//		StartCoroutine(playVideo(shutter[2],videoToPlay2));
	}

	/// <summary>
	/// Loads shutters from Hierarchy.
	/// </summary>
	private void LoadReferences()
	{
		uiManager = transform.GetComponentInParent<UIManager> ();
		shutter = new Transform[transform.childCount];
		for (int i = 0; i < shutter.Length; i++)
			shutter [i] = transform.GetChild (i);
	}


	/// <summary>
	/// Updates the shutter position.
	/// </summary>
	public void UpdateShutter(bool value)
	{
		uiManager.ShowCategorySelector (false);
		uiManager.ShowGenderSelection (false);
		uiManager.ShowScale (false);
//		for (int i = 0; i < shutter.Length; i++) 
		{
			int i = 1;
			shutter [i].GetComponent<Animator> ().SetBool ("open", value);
//			if (value) 
//			{
//				shutter [i].GetComponent<VideoPlayer> ().Stop ();
//				shutter [i].GetComponent<VideoPlayer> ().enabled = false;
//			}
			
		}
	}

	/// <summary>
	/// Raises the animation end event.
	/// </summary>
	public void OnShutterOpneAnimationEnd()
	{
//		uiManager.ShowStartPage(true);
		FittingRoomSample.GetInstance ().trialCloth.gameObject.SetActive(true);
		FittingRoomSample.GetInstance ().SetSelectedCloth (FittingRoomSample.GetInstance ().trialCloth);
		FittingRoomSample.GetInstance ().trialTextures.SetActive(true);
		StopAllCoroutines ();
	}


	IEnumerator playVideo(Transform door, VideoClip videoToPlay)
	{
		VideoPlayer videoPlayer = door.gameObject.AddComponent<VideoPlayer>();
		videoPlayer.playOnAwake = false;
		videoPlayer.isLooping = true;

		videoPlayer.source = VideoSource.VideoClip;
		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare();
		while (!videoPlayer.isPrepared)
		{
			yield return null;
		}
		door.GetComponent<RawImage>().texture = videoPlayer.texture;
		videoPlayer.Play();
		while (videoPlayer.isPlaying)
		{
			yield return null;
		}
	}
}
