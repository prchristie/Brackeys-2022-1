using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    public int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        CheckIfDead();
    }

    private void OnDeathSequence()
    {
        onDeath?.Invoke();
    }

    private bool IsAlive()
    {
        return currentHealth > 0;
    }

    private void CheckIfDead()
    {
        if (!IsAlive())
        {
            OnDeathSequence();
        }
    }

    // Triggered when currentHealth is less or equal to 0
    public UnityEvent onDeath;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        CheckIfDead();
    }
}
