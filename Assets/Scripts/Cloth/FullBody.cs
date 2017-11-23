using LightBuzz.Vitruvius.Avateering;

public class FullBody : AvatarCloth
{
	public override void OnUpdate()
	{
		UpdateBone(Avateering.SpineBase);


		UpdateBone(Avateering.SpineBase);
		UpdateBone(Avateering.Neck);

		UpdateBone(Avateering.ShoulderLeft);
		UpdateBone(Avateering.ElbowLeft);

		UpdateBone(Avateering.ShoulderRight);
		UpdateBone(Avateering.ElbowRight);


		UpdateBone(Avateering.HipLeft);
		UpdateBone(Avateering.KneeLeft);
		UpdateBone(Avateering.AnkleLeft, 7);

		UpdateBone(Avateering.HipRight);
		UpdateBone(Avateering.KneeRight);
		UpdateBone(Avateering.AnkleRight, 7);
	}
}