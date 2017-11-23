using LightBuzz.Vitruvius.Avateering;
using UnityEngine;

public class TShirt : AvatarCloth
{


	void Start()
	{
		Initialize ();
	}

    public override void OnUpdate()
    {

		if (!updateJoints) 
		{
			return;
		}


		UpdateBone(Avateering.ShoulderLeft);
		UpdateBone(Avateering.ElbowLeft);
		UpdateBone(Avateering.ShoulderRight);
		UpdateBone(Avateering.ElbowRight);	
		UpdateBone(Avateering.SpineBase);
        UpdateBone(Avateering.SpineMid);
        UpdateBone(Avateering.Neck);
        
    }
}