using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{

    public static TurretSpawner Singleton { get; private set; }
    
    private class TurretLocation
    {
        public readonly Transform location;
        [CanBeNull] public Turret Turret { get; set; }

        public TurretLocation(Transform location)
        {
            this.location = location;
            Turret = null;
        }
    }
    public List<Transform> turretLocations;
    public Turret turretPrefab;

    private List<TurretLocation> _locations;
    private Dictionary<int, TurretLocation> _spawnedTurrets;

    private void Awake()
    {
        if(Singleton != null) Destroy(gameObject);
        Singleton = this;
        
        _spawnedTurrets = new Dictionary<int, TurretLocation>(turretLocations.Count);
        _locations = new List<TurretLocation>(turretLocations.Count);
        
        foreach(var t in turretLocations)
        {
            _locations.Add(new TurretLocation(t));
        }
    }

    [CanBeNull]
    public Turret SpawnNewTurret()
    {
        foreach (var tl in _locations)
        {
            if (tl.Turret != null) continue;
            tl.Turret = Instantiate(turretPrefab, tl.location.position, Quaternion.identity);
            _spawnedTurrets.Add(tl.Turret!.GetInstanceID(), tl);
            return tl.Turret;
        }

        return null;
    }

    public void DestroyTurret(Turret turret)
    {
        if (turret == null || !_spawnedTurrets.ContainsKey(turret.GetInstanceID())) return;
        var tl = _spawnedTurrets[turret.GetInstanceID()];
        tl.Turret = null;
        Destroy(turret.gameObject);
    }
}