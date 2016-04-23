using UnityEngine;
using System.Collections;

public enum Movement
{
    Horizontal,
    Vertical
}

public class OrientAlongMovement : MonoBehaviour
{
    public float MaxOrientation;
    public float SpeedRotation = 10.0f;
    public  MoveController MovementController;
    public Movement MovementType = Movement.Horizontal;
	
	void Update ()
	{
        Quaternion targetOrientation = new Quaternion();
        if(MovementType == Movement.Horizontal)
            targetOrientation = Quaternion.AngleAxis(MovementController.Direction.x*MaxOrientation*-1, Vector3.forward);
        else
            targetOrientation = Quaternion.AngleAxis(MovementController.Direction.y * MaxOrientation, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientation, Time.deltaTime * SpeedRotation);
    }
}
