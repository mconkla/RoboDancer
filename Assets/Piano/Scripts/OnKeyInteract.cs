using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnKeyInteract : UnityEngine.XR.Interaction.Toolkit.XRSimpleInteractable
{
    public KeyType keyType;
    public enum KeyType
    {
        black,white
    }
    private Animator _animator;

    public AudioSource _AudioSource;
    
    protected override void Awake()
    {
        base.Awake();
        _animator = transform.parent.GetComponent<Animator>();
        _AudioSource = GetComponent<AudioSource>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        Debug.Log(gameObject.name + " KEY DOWN");
        _animator.Play("keyDown");
        
        if(_AudioSource != null)
            _AudioSource.PlayOneShot(_AudioSource.clip);

    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        Debug.Log(gameObject.name + " KEY UP");
        _animator.Play("keyUp");
        
    }
    
    
    
}
