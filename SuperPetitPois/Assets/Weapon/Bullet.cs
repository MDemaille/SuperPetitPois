using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public List<string> TargetsTags;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (TargetsTags.Contains(collision.tag))
        {
            collision.GetComponent<HealthManager>().TakeDamage(Damage);
        }
    }

}
