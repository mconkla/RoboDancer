using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalRow : MonoBehaviour
{

    public enum RowType
    {
        kick,snare,clap,hihat
    }
    
    public RowType rowType;
    
    public GameObject rowSlotGameObject;
    public GameObject placeCubeGameObject;
    
    public List<PlaceCube> placeCubesActive;
    public List<RowSlot> rowSlotsActive;
    
    [SerializeField]
    private int slotCount;
    [SerializeField]
    [Range(0.1f,2.0f)]
    private float cubeSize = 1.0f;
    [SerializeField]
    private float offset = 0.1f;
    
    
    public GameObject[] placeCubeVariants;

    private void Awake()
    {
        placeCubesActive = new List<PlaceCube>();
        rowSlotsActive = new List<RowSlot>();
        
        for (var i = 0; i < slotCount; i++)
        {
            SpawnSlot(i);
        }

        GetPlaceCubeVariantByName();
    }

    private void GetPlaceCubeVariantByName()
    {
        foreach (var placeCubeVariant in placeCubeVariants)
        {
            if (placeCubeVariant.name.ToLower().Contains(rowType.ToString().ToLower()))
            {
                placeCubeGameObject = placeCubeVariant;
            }
        }
    }
    private void SpawnSlot(int cubeNumber)
    {
        var slot = Instantiate(rowSlotGameObject, this.transform);
        var xPos = (cubeSize * cubeNumber) + (offset * cubeNumber);
        slot.transform.position = new Vector3(xPos,this.transform.position.y, this.transform.position.z);
        var tempSlot = slot.GetComponent<RowSlot>();
        tempSlot.InitCube(cubeSize,rowType);
        rowSlotsActive.Add(tempSlot);
    }


    public void AddCubeType()
    {
        if (placeCubesActive.Count >= rowSlotsActive.Count) return;
        var cubeTemp = Instantiate(placeCubeGameObject, this.transform);
        cubeTemp.transform.parent = null;

        var nextSpawnPos = GetNextSpawnPos();
        var spawnPos = rowSlotsActive[nextSpawnPos].transform.position;
        spawnPos.y += 1f;
        cubeTemp.transform.position = spawnPos;
        var placeCubeTemp = cubeTemp.GetComponent<PlaceCube>();
        placeCubeTemp.tag = rowType.ToString();
        placeCubeTemp.zForce = this.transform.position.z;
        placeCubesActive.Add(placeCubeTemp);
    }

    public void DeleteCubeType()
    {
        if (placeCubesActive.Count <= 0) return;
        
        var placeCubeToRemove = placeCubesActive[placeCubesActive.Count - 1];
        placeCubesActive.Remove(placeCubeToRemove);
        placeCubeToRemove.KillPlaceCube();

    }


    private int GetNextSpawnPos()
    {
        var indexToSpawnAt = 0;
        for (; indexToSpawnAt < rowSlotsActive.Count; indexToSpawnAt++)
        {
            if(rowSlotsActive[indexToSpawnAt].activated) continue;
          
            break;
            
        }

        return indexToSpawnAt;
    }

}
