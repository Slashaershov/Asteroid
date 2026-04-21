using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    
    private float _nextSpawnTime;
    private float _spawnDuration = 2f;
    private AsteroidSpawner _asteroidSpawner;

    [Inject]
    public void Construct(AsteroidSpawner asteroidSpawner)
    {
        _asteroidSpawner = asteroidSpawner;
    }

    private void Update()
    {
        TrySpawnEnemy();
    }

    private void TrySpawnEnemy()
    {
        if (_nextSpawnTime < Time.time)
        {
            _nextSpawnTime = Time.time + _spawnDuration;
            SpawnEnemy();
        }

    }

    private void SpawnEnemy()
    {
        if (_points == null || _points.Count == 0) return;
        var randomPoint = _points[Random.Range(0, _points.Count)];
        var asteroid = _asteroidSpawner.Spawn(randomPoint.position, -randomPoint.position);
    }
    
}

public enum EnemyType
{

}
