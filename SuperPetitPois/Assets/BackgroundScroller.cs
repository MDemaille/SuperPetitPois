using UnityEngine;
using System.Collections;

public enum ScrollMode
{
    Horizontal,
    Vertical
}

public class BackgroundScroller : MonoBehaviour
{
    private Transform _background;
    public float SpeedScroll = 1;
    public bool Reverse = false;
    public ScrollMode Scroll = ScrollMode.Horizontal;
    public float Size { get; private set; }
    public Vector2 DistanceOnOneFrame { get; private set; }
    public Vector2 ScrollDirection { get; private set; }

    private GameObject[] _backgrounds;

    // Use this for initialization
    void Start()
    {
        _background = transform.Find("view");
        if (Scroll.Equals(ScrollMode.Horizontal))
        {
            ScrollDirection = Vector2.left;
            Size = _background.GetComponent<BoxCollider2D>().size.x;
        }
        else
        {
            ScrollDirection = Vector2.up;
            Size = _background.GetComponent<BoxCollider2D>().size.y;
        }

        if (Reverse)
        {
            ScrollDirection *= -1;
        }

        _backgrounds = new GameObject[3];
        _backgrounds[0] = _background.gameObject;
        _backgrounds[1] = Instantiate(_background.gameObject, _background.position - (((Vector3)ScrollDirection * Size)), Quaternion.identity) as GameObject;
        _backgrounds[1].transform.SetParent(transform);
        _backgrounds[2] = Instantiate(_background.gameObject, _background.position - (((Vector3)ScrollDirection * Size * 2)), Quaternion.identity) as GameObject;
        _backgrounds[2].transform.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        DistanceOnOneFrame = ScrollDirection * SpeedScroll * Time.deltaTime * LevelManager.BackgroundSpeedTimer;
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            _backgrounds[i].transform.Translate(DistanceOnOneFrame, Space.World);
        }
    }

    public void ResetBackground()
    {
        Collider2D collider = _backgrounds[2].GetComponent<Collider2D>();
        Vector2 position = new Vector2(collider.bounds.max.x, collider.bounds.min.y);

        _backgrounds[0].transform.position = position;
        GameObject background0 = _backgrounds[0];
        GameObject background1 = _backgrounds[1];
        GameObject background2 = _backgrounds[2];

        _backgrounds[0] = background1;
        _backgrounds[1] = background2;
        _backgrounds[2] = background0;
    }
}
