using UnityEngine;
using System.Collections;

public class ClampToBoundaries : MonoBehaviour
{
    private float _xmin;
    private float _xmax;
    private float _ymin;
    private float _ymax;

    void Start()
    {
        Collider2D boundary = GameObject.FindGameObjectWithTag(Tags.Boundary).GetComponent<BoxCollider2D>();
        _xmin = boundary.bounds.min.x;
        _xmax = boundary.bounds.max.x;
        _ymin = boundary.bounds.min.y;
        _ymax = boundary.bounds.max.y;
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,_xmin,_xmax), Mathf.Clamp(transform.position.y,_ymin,_ymax));
    }
}
