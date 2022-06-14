using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnCube : MonoBehaviour
{
    private Material _myMaterial;
    public void SetMaterial(Material _material)
    {
        _myMaterial = _material;
        GetComponent<MeshRenderer>().material = _material;
    }

    public void OnSpawnFromPull(XRGrabInteractable interactable)
    {
        interactable.selectExited = new SelectExitEvent();
    }

    public void OnHoverEntered()
    {
        _myMaterial.color = new Color(1, 0, 0);
    }

    public void OnHoverExited()
    {
        _myMaterial.color = new Color(1, 1, 1);
    }
}
