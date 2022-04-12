using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSlot : MonoBehaviour
{
    public bool activated = false;
    public PhysicalRow.RowType _rowType;
    public PlaceCube currentPlaceCube;
    
    [SerializeField]
    private Material defaultMaterial, activatedMaterial;

    private MeshRenderer _meshRenderer;
    
    
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
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
    }

    #endregion
    

}
