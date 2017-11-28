using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EGender
{
	MALE,
	FEMALE
}

public enum ECategory
{
	COLLARED_TSHIRT = 0,
	FULL_TSHIRT = 1,
	HALF_TSHIRT = 2,
	JACKET = 3,
	PANT = 4,
	SHIRT = 5,
	SHORTS = 6,
	SHORTS_XS = 7,
}

public enum EGarment
{
	ONE = 1,
	TWO = 2,
	THREE = 3,
	FOUR = 4,
}

public enum EScale
{
	INCREMENT,
	DECREMENT
}


public enum UIState
{
	LOGIN_SCREEN,
	ADMIN_SCREEN,
	SETTINGS_SCREEN,
}


public enum PopUpState
{
	SYNC,
}

public class AppConstants 
{
	public const float SPINNER_ANGLE = 45f;
	public const float SPINNER_DELAY = 0.1f;

}
