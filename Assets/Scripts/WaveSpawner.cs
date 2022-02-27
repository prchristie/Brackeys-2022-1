using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Required]
    [SerializeField] private Transform spawnLocation;
    [Required]
    [SerializeField] private LevelConfig level;

    private WaveConfig _currentWave;
    private float _timer;
    private int _currentPlace;
    private bool _spawning;

    private void Start()
    {
        _currentWave = level.waves[0];
        _timer = _currentWave.timeToStart;
        _spawning = false;
        _currentPlace = 0;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0 && !_spawning)
        {
            StartCoroutine(StartWave());
        }
    }

    private IEnumerator StartWave()
    {
        _spawning = true;
        
        foreach (var unit in _currentWave.wave)
        {
            var monster = unit.monster;
            for (var i = 0; i < unit.number; i++)
            {
                Monster m = Instantiate(monster, spawnLocation.position + (Vector3)Random.insideUnitCircle, monster.transform.rotation);
                m.GetComponent<MonsterHealth>().maxHealth = (int) DifficultyLevel.MonsterHealth();
                m.GetComponent<MonsterHealth>().currentHealth = (int) DifficultyLevel.MonsterHealth();
                m.GetComponent<MonsterMovementHandler>().speed = DifficultyLevel.MonsterSpeed();
                yield return new WaitForSeconds(DifficultyLevel.SpawnSpeed());
            }
        }

        _spawning = false;
        _currentPlace++;
        if (_currentPlace > level.waves.Count) yield break;
        _currentWave = level.waves[_currentPlace];
        _timer = _currentWave.timeToStart;
    }

    private class DifficultyLevel
    {
        public static float SpawnSpeed()
        {
            float timePassed = Time.timeSinceLevelLoad;
            float spawnSpeed = 0.5f - (timePassed / 120f);
            return spawnSpeed < 0.03f ? 0.03f : spawnSpeed;
        }

        public static float MonsterHealth()
        {
            float timePassed = Time.timeSinceLevelLoad;

            float health = 1f + ((timePassed*timePassed) / 150f);

            return health;
        }

        public static float MonsterSpeed()
        {
            float timePassed = Time.timeSinceLevelLoad;

            float speed = 2f + (timePassed / 20f);

            return speed;
        }
    }
}
