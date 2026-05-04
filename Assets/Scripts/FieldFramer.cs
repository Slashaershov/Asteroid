using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System;
using Zenject;

public class FieldFramer: MonoBehaviour
{
    public PlayerMoved _player;
    public Transform limitUpLeft;
    public Transform limitDownRight;

    private float _limitUp;
    private float _limitDown;
    private float _limitRight;
    private float _limitLeft;

    [Inject]
    public void Constact(PlayerMoved player)
    {
        _player = player;
        _limitUp = limitUpLeft.position.y;
        _limitLeft = limitUpLeft.position.x;
        _limitDown = limitDownRight.position.y;
        _limitRight = limitDownRight.position.x;
        _player.SetAction(OnMove);
    }

    private void OnMove()
    {
        var targetPos = Teleport(_player.GetPosition());
        _player.SetPosition(targetPos);

    }

    private Vector2 Teleport(Vector2 point)
    {
        var targetPosX = Teleport(point.x, _limitRight, _limitLeft);
        var targetPosY = Teleport(point.y, _limitUp, _limitDown);
        Debug.LogError(new Vector2(targetPosX, targetPosY));
        return new Vector2(targetPosX, targetPosY);
    }

    private float Teleport(float x, float max, float min)
    {
        if (x > max)
        {
            return min;
        }
        if (x < min)
        {
            return  max;
        }
        return x;
    }

}
