using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ShootingComponent 
{
    private float _nextShootTime;
    private float _shootDelay = 1f;
    private ProjectileSpawner _projectileSpawner;
    private PlayerMoved _player;


    public ShootingComponent(PlayerMoved player, ProjectileSpawner projectileSpawner)
    {
        _player = player;
        _projectileSpawner = projectileSpawner;
    }

    public void Shoot()
    {
        if (Time.time > _nextShootTime)
        {
            _nextShootTime = Time.time + _shootDelay;
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        _projectileSpawner.Spawn(new MoveParams(_player.GetPosition(), Vector2.up, 1f));
    }
}
