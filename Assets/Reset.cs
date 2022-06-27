using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    
    public void ResetScene()
    {
        var physicalRows = FindObjectsOfType<PhysicalRow>();
        foreach (var physicalRow in physicalRows)
        {
            physicalRow.DeleteAllActiveCubes();
        }
    }
}
