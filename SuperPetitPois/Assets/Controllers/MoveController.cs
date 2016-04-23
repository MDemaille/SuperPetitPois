using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    [HideInInspector]
    public Vector2 Direction;
    public PhysicsProperties PhysicsValues;

    public virtual void Update()
    {
        transform.Translate(Direction * PhysicsValues.Speed*Time.deltaTime, Space.World);
    }
}
