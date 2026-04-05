// See https://aka.ms/new-console-template for more information
using UnityEngine;

public interface IMoved
{
    public void UpdateMovement(float deltaTime);

    public Vector2 GetPosition();
}
