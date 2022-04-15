using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnKeyInteract : UnityEngine.XR.Interaction.Toolkit.XRSimpleInteractable
{
    private Animator _animator;

    
    protected override void Awake()
    {
        base.Awake();
        _animator = transform.parent.GetComponent<Animator>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        Debug.Log(gameObject.name + " KEY DOWN");
        _animator.Play("keyDown");
        
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        Debug.Log(gameObject.name + " KEY UP");
        _animator.Play("keyUp");
        
    }
    
    
    
}
