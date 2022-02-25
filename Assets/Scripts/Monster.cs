using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(MonsterHealth))]
public class Monster : MonoBehaviour
{
    [Required, Searchable]
    [SerializeField] private ParticleSystem onDeathEffect;
    [Required]
    [SerializeField] private AudioClip onDeathSound;

    [Required]
    [SerializeField]
    private Transform playSoundLocation;
    
    private void Awake()
    {
        var health = GetComponent<MonsterHealth>();
        health.onDeath.AddListener(OnDeath);
    }

    private void OnDeath()
    {
        AudioSource.PlayClipAtPoint(onDeathSound, playSoundLocation.position, 5);
        Instantiate(onDeathEffect, transform.position, onDeathEffect.transform.rotation);
        Destroy(gameObject);
    }
}
