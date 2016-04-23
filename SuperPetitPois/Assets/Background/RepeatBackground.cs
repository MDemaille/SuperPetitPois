using UnityEngine;
using System.Collections;

public class RepeatBackground : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Background))
        {
            collision.transform.parent.GetComponent<BackgroundScroller>().ResetBackground();
        }   
    }
}
