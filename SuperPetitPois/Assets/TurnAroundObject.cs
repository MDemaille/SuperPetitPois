using UnityEngine;
using System.Collections;

public class TurnAroundObject : MonoBehaviour
{
    public Transform ObjectToTurnAround;
    public float Speed;
    public bool FreezeLocalRotation = true;

	void Update ()
    {
	    transform.RotateAround(ObjectToTurnAround.position, Vector3.forward, Speed*Time.deltaTime);
        if(FreezeLocalRotation)
            transform.localRotation = Quaternion.identity;
	}
}
