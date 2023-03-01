using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{

    public int Health = 5;
    public int MaxHealth = 8;
    //public AudioSource DamageSound;
    //public AudioSource HealSound;

    public HealthUI HealthUI;
    public DamageScreen DamageScreen;

    public UnityEvent EventOnTakeDamage;

    private bool _invulnerable = false;

    private void Start()
    {
        DamageScreen.HideImage();
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            if (Health > 0)
            {
                Health -= damageValue;
                DamageScreen.StartEffect();
                EventOnTakeDamage.Invoke();
                _invulnerable = true;
                Invoke("StopInvulnerable", 1f);
            }
            else
            {
                Health = 0;
                Die();
            }
        }
        HealthUI.DisplayHealth(Health);
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        Health += healthValue;
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        //HealSound.Play();
        HealthUI.DisplayHealth(Health);
    }

    void Die()
    {
        Debug.Log("Game Over");
    }
}
