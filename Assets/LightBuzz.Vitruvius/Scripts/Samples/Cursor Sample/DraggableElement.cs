using UnityEngine;

public class DraggableElement : KinectButton
{
	private Vector3 position;
	bool resetPosition = false;

	void OnEnable()
	{
		position = transform.position;
	}

	public void ResetPosition()
	{
		resetPosition = true;
		transform.position = position;
		Invoke ("DisableResetPosition", 2.0f);
	}

	void DisableResetPosition()
	{
		resetPosition = false;
	}

    protected override void OnDragging()
    {
		if(!resetPosition)
			transform.position = cursorInfo.currentPosition;
    }

    protected override void OnOutsideDragging()
    {
        OnDragging();
    }
}