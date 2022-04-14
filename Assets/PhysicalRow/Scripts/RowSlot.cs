using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSlot : MonoBehaviour
{
    public bool activated = false;
    public PhysicalRow.RowType _rowType;
    public PlaceCube currentPlaceCube;
    public AudioClip kickClip, snareClip, hihatClip, clapClip;
    
    [SerializeField]
    private Material defaultMaterial, activatedMaterial;

    private MeshRenderer _meshRenderer;



    private AudioSource _audioSource;
    
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        _meshRenderer.material = activated ? activatedMaterial : defaultMaterial;
    }

    #region  publicfunctions

    public void InitCube(float cubeSize,PhysicalRow.RowType rowType)
    {
        _rowType = rowType;
        transform.localScale = new Vector3(cubeSize,cubeSize,cubeSize);
        switch (_rowType)
        {
            case PhysicalRow.RowType.clap:
                _audioSource.clip = clapClip;
                break;
            case PhysicalRow.RowType.hihat:
                _audioSource.clip = hihatClip;
                break;
            case PhysicalRow.RowType.kick:
                _audioSource.clip = kickClip;
                break;
            case PhysicalRow.RowType.snare:
                _audioSource.clip = snareClip;
                break;
        }
    }

    public void PlayRowSlot()
    {
        if (!activated) return;
      
        _audioSource.Play();
    }

    #endregion
    

}
