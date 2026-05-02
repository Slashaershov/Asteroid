using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class LaserActivator
{
    private float _reloadingTime;
    private float _nextShootTime;
    private Action _onActivate;

    public LaserActivator (float reloadingTime)
    {
        _reloadingTime = reloadingTime;
    }

    public void SetAction(Action onActivate)
    {
        _onActivate = onActivate;
    }

    public void Activate()
    {
        if (Time.time > _nextShootTime)
        {
            _nextShootTime = Time.time + _reloadingTime;
            _onActivate?.Invoke();
        }
    }
}

