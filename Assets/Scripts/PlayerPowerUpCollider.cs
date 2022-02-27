using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpCollider : MonoBehaviour
{
    public PowerUp powerUp;
    private GameObject _player;

    public int health;

    private void Awake()
    {
        this._player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        health--;

        if (health > 0) return;
        
        foreach(var effect in powerUp.effects)
            SoundSystem.PlaySound(effect.pickupSound);
        powerUp = Instantiate(powerUp);
        powerUp.InitPowers();
        powerUp.RunPower(_player);
        Destroy(gameObject);
    }
}
