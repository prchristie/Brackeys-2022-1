using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterHealth))]
public class MonsterCollisionHandler : MonoBehaviour
{
    private MonsterHealth _health;

    private void Awake()
    {
        _health = GetComponent<MonsterHealth>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Projectile"))
        {
            ProjectileCollision(col.transform.GetComponent<Projectile>());
        }
    }

    private void ProjectileCollision(Projectile proj)
    {
        _health.TakeDamage(proj.damage);
    }
}
