using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    
    private float _nextSpawnTime;
    private float _spawnInterval  = 2f;
    private List<IEnemySpawner> _spawners;

    [Inject]
    public void Construct(AsteroidSpawner asteroidSpawner, FlyTapeSpawner flyTapeSpawner)
    {
        _spawners = new List<IEnemySpawner>();
        _spawners.Add(asteroidSpawner);
        _spawners.Add(flyTapeSpawner);
    }

    private void Update()
    {
        TrySpawnEnemy();
    }

    private void TrySpawnEnemy()
    {
        if (_nextSpawnTime < Time.time)
        {
            _nextSpawnTime = Time.time + _spawnInterval ;
            SpawnEnemy();
        }

    }

    private void SpawnEnemy()
    {
        if (_spawners.Count == 0 || _points.Count == 0) return;

        var randomPoint = _points[Random.Range(0, _points.Count)];
        var spawner = _spawners[Random.Range(0, _spawners.Count)];
        var moveParams = new MoveParams(randomPoint.position, -randomPoint.position, 1f);
        var enemy = spawner.Spawn(moveParams);
    }
    
}

