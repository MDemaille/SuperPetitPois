using UnityEngine;
using System.Collections;

public class OrientBulletAlongMovement : MonoBehaviour {

    private MoveController _moveController;

    void Start()
    {
        _moveController = GetComponent<MoveController>();

        float angle = Mathf.Atan2(_moveController.Direction.y, _moveController.Direction.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.localRotation = q;
    }


}
