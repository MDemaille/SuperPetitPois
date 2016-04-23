using UnityEngine;
using System.Collections;

public class RotateAlongMovement : MonoBehaviour
{
    public float MaxRotation = 45;

    public bool HorizontalMovement;
    public bool VerticalMovement;

    private Vector3 _lastPosition;

    private float _velocityX;
    private float _velocityY;

    void Start ()
	{
	    _lastPosition = transform.position;
	}
	
	void Update ()
	{
	    Vector3 direction = (transform.position - _lastPosition).normalized;
	    if (HorizontalMovement)
	    {
	        float targetRotation = direction.x*MaxRotation;
	        float newRotation = Mathf.SmoothDamp(transform.localRotation.eulerAngles.z, targetRotation, ref _velocityX, 0.2f);
            transform.localRotation = Quaternion.AngleAxis(newRotation, Vector3.forward);
	    }
	    _lastPosition = transform.position;
	}
}
