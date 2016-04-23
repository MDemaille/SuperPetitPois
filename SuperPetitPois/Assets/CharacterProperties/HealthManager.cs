using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public HealthProperties properties;
    public float CurrentHealth { get; private set; }

    public virtual void Start()
    {
        CurrentHealth = properties.MaxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth <= 0) Death();
    }

    public virtual void Death()
    {
        Debug.Log("Death");
    }
}
