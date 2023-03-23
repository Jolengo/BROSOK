using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{

    public int Health = 1;
    public UnityEvent DieEffect;

    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    public void Die()
    {
        DieEffect.Invoke();
        Destroy(gameObject);
    }
}
