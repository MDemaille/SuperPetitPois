using UnityEngine;
using System.Collections;

public class DestroyShotsOutOfScreen : MonoBehaviour {

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Shots))
        {
            Destroy(collision.gameObject);
        }
    }
}
