using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth { get; private set; }

    public virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth <= 0) Death();
    }

    public virtual void GainLife(float life)
    {
        CurrentHealth += life;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }

    public virtual void Death()
    {
        Debug.Log("Death");
    }
}
