using UnityEngine;

public class InfiniteRotation : MonoBehaviour
{
    public float AngularSpeed = 200;

    void Update()
    {
        transform.Rotate(Vector3.forward, AngularSpeed * Time.deltaTime, Space.Self);
    }
}
