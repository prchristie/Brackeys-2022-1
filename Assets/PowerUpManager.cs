using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Singleton;
    public List<PlayerPowerUpCollider> powerUpPrefabs;

    private void Awake()
    {
        if(Singleton != null) Destroy(this);
        Singleton = this;
    }

    public PlayerPowerUpCollider SpawnNewPowerUp()
    {
        PlayerPowerUpCollider obj = Instantiate(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Count)]);

        return obj;
    }
}
