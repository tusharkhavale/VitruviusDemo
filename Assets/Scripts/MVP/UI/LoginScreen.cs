using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour {


	private InputField inputId;
	private InputField inputPassword;
	private Button btnSubmit;
	private UIController uiController;


	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		LoadReferences ();
		AddButtonListners ();
	}

	/// <summary>
	/// Loads the references.
	/// </summary>
	private void LoadReferences()
	{
		inputId = transform.Find ("IdInput").GetComponent<InputField> ();
		inputPassword = transform.Find ("PasswordInput").GetComponent<InputField> ();
		btnSubmit = transform.Find ("SubmitBtn").GetComponent<Button> ();
		uiController = transform.GetComponentInParent<UIController> ();
	}

	/// <summary>
	/// Adds the button listners.
	/// </summary>
	private void AddButtonListners()
	{
		btnSubmit.onClick.AddListener (this.OnClickSubmit);
	}

	/// <summary>
	/// Raises the click submit event.
	/// </summary>
	private void OnClickSubmit()
	{
		uiController.OnClickSubmit (inputId.text,inputPassword.text);
	}

}
