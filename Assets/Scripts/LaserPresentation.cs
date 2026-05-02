using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LaserPresentation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [Inject]
    public void Construct(LaserActivator logic) 
    {
        logic.SetAction(Activate);
    }

    public void OnAnimationFinished()
    {
        _animator.gameObject.SetActive(false);
    }


    private void Activate()
    {
        _animator.gameObject.SetActive(true);
    }
}
