using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamageOnCollision : MonoBehaviour
{

    public EnemyHealth EnemyHealth;
    public UnityEvent EventOnTakeDamageEnemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0)
        {
            EventOnTakeDamageEnemy.Invoke();
            EnemyHealth.TakeDamage(1);
        }  
    }
}
