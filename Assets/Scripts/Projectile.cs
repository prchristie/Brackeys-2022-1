using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public int damage;
    public float lifeTime;
    public ParticleSystem onHitEffect;
    public AudioClip onHitSound;

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(onHitEffect, transform.position, Quaternion.identity);
        SoundSystem.PlaySound(onHitSound);
        Destroy(gameObject);
    }
}
