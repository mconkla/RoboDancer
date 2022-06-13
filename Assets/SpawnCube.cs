using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnCube : MonoBehaviour
{
    public void SetMaterial(Material _material)
    {
        GetComponent<MeshRenderer>().material = _material;
    }

    public void OnSpawnFromPull(XRGrabInteractable interactable)
    {
        interactable.selectExited = new SelectExitEvent();
    }

    public void OnHoverEntered()
    {
        
    }

    public void OnHoverExited()
    {
        
    }
}
