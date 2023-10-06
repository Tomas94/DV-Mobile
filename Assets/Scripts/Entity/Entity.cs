using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float currentLife;

    public abstract void Disparar();
    public abstract void Die();

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
    }
}
