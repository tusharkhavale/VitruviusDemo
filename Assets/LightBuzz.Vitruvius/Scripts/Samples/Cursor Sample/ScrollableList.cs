using UnityEngine;

public class ScrollableList : KinectButton
{
    public Transform listParent;

    protected override void OnDragging()
    {
//		listParent.position += new Vector3(cursorInfo.Direction.x, 0, 0);
		listParent.Rotate(0,cursorInfo.Direction.x, 0);
    }

    protected override void OnOutsideDragging()
    {
        OnDragging();
    }
}