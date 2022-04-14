using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaceCube : XRGrabInteractable
{
    public float size = 0.3f;
    [SerializeField]
    private Material defaultMaterial, grabbedMaterial;
    private MeshRenderer _meshRenderer;
    private bool _isGrabbed = false;
    private XRRayInteractor[] _allXRayInteractor;

    private RowSlot _connectedRowSlot;
    private void Awake()
    {
        base.Awake();
        _meshRenderer = GetComponent<MeshRenderer>();
        _allXRayInteractor = FindObjectsOfType<XRRayInteractor>();
        transform.localScale = new Vector3(size, size, size);

    }
    private void Update()
    {
        _meshRenderer.material = _isGrabbed ? grabbedMaterial : defaultMaterial;
        SetAttachTransforms();
    }

    public void SnapPosition(RowSlot rowSlot)
    {
        _connectedRowSlot = rowSlot;
        var newPos = rowSlot.transform.position;
        newPos.y += rowSlot.transform.localScale.y;
        this.transform.position = newPos;
    }

    public void KillPlaceCube()
    {
        _connectedRowSlot.activated = false;
        Destroy(this.gameObject);
    }

    private void SetAttachTransforms()
    {
        for (var i = 0; i < _allXRayInteractor.Length; i++)
        {
            var tempXRayInteract = _allXRayInteractor[i];
            if (tempXRayInteract.attachTransform == null) continue;
            
            
            var posRight = tempXRayInteract.attachTransform.position;
            posRight.z = 0;
            tempXRayInteract.attachTransform.position = posRight;
        }
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        var pos = transform.position;
        for (var i = 0; i < _allXRayInteractor.Length; i++)
        {
            var tempXRayInteract = _allXRayInteractor[i];
            if (tempXRayInteract.attachTransform == null) continue;
            tempXRayInteract.attachTransform.position = pos;
            
        }
        
        Debug.Log("GRABBING OBJECT");
        _isGrabbed = true;
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        Debug.Log("UNGRABBING OBJECT");
        _isGrabbed = false;
    }
    
    
    
    #region trigger
    private void OnTriggerStay(Collider other)
    {
        var rowSlot = other.gameObject.GetComponent<RowSlot>();
        if (rowSlot != null)
        {
            if (gameObject.tag.ToLower().Equals(rowSlot._rowType.ToString()))
            {
                if (rowSlot.currentPlaceCube == null || rowSlot.currentPlaceCube.Equals(this))
                {
                    rowSlot.currentPlaceCube = this;
                    rowSlot.activated = true;
                    SnapPosition(rowSlot);
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        var rowSlot = other.gameObject.GetComponent<RowSlot>();
        if (rowSlot != null)
        {
            if (gameObject.tag.ToLower().Equals(rowSlot._rowType.ToString()))
            {
                rowSlot.activated = false;
                rowSlot.currentPlaceCube = null;
            }
        }
    }
    #endregion
}
