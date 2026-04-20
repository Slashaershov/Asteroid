using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Zenject;

public class PlayerPresentation : ObjectPresentation
{
    [Inject]
    public void Construct(IMoved moved)
    {
        SetMoved(moved);
    }
}
