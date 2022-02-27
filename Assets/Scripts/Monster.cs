using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MonsterHealth))]
public class Monster : MonoBehaviour
{
    [Required, Searchable]
    [SerializeField] private ParticleSystem onDeathEffect;
    [Required]
    [SerializeField] private AudioClip onDeathSound;

    [SerializeField] private float chanceToSpawnPowerUp;
    
    private Transform _playSoundLocation;

    private void Awake()
    {
        var health = GetComponent<MonsterHealth>();
        health.onDeath.AddListener(OnDeath);
        _playSoundLocation = Camera.main.transform;
    }

    private void OnDeath()
    {
        if (Random.Range(0f, 1f) < chanceToSpawnPowerUp)
        {
            var pu = PowerUpManager.Singleton.SpawnNewPowerUp();
            pu.transform.position = transform.position;
        }
        
        AudioSource.PlayClipAtPoint(onDeathSound, _playSoundLocation.position, 5);
        Instantiate(onDeathEffect, transform.position, onDeathEffect.transform.rotation);
        Score.Singleton.IncreaseScore();
        Destroy(gameObject);
    }
}
