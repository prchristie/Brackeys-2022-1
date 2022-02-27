using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ExtraTurretEffect", fileName = "ExtraTurretEffect", order = 0)]
public class ExtraTurretEffect : Effect
{
    private TurretSpawner _spawner;
    private Turret _spawnedTurret;
    
    public override void Init()
    {
        _spawner = TurretSpawner.Singleton;
    }

    public override IEnumerator StopEffect(GameObject obj)
    {
        _spawner.DestroyTurret(_spawnedTurret);
        yield break;
    }

    public override IEnumerator StartEffect(GameObject obj)
    {
        _spawnedTurret = _spawner.SpawnNewTurret();
        yield break;
    }
}