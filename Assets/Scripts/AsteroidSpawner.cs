using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Assets.Scripts;

public class AsteroidSpawner : MonoBehaviour
{
    private DiContainer _container;
    private ConstMoveFactory _constMoveFactory;

    [SerializeField] private GameObject _asteroidPrefab;

    public void OnEnable()
    {
        Spawn(Vector2.zero);
    }

    [Inject]
    public void Constract(DiContainer container, ConstMoveFactory constMoveFactory)
    {
        _container = container;
        _constMoveFactory = constMoveFactory;
    }

    public AsteroidPresentation Spawn(Vector3 position)
    {
        var move = _constMoveFactory.Create(position);
        var asteroid = _container.InstantiatePrefabForComponent<AsteroidPresentation>(
            _asteroidPrefab,
            position,
            Quaternion.identity,
            null
        );

        asteroid.SetMoved(move);
        return asteroid;
    }
}

public interface IMovedFactory<T> where T : IMoved
{
    T Create(Vector2 pos);
}

public class ConstMoveFactory : IMovedFactory<ConstSpeedMovedObject>
{
    public ConstSpeedMovedObject Create(Vector2 pos)
    {
        return new ConstSpeedMovedObject(pos, Vector2.up, 1f);
    }
}

