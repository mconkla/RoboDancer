using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoSoundManagement : MonoBehaviour
{
    public List<OnKeyInteract> blackKeys;
    public List<OnKeyInteract> whiteKeys;
   
    public AudioClip pianoSoundClip;
    
    private void Awake()
    {
        blackKeys = new List<OnKeyInteract>();
        whiteKeys = new List<OnKeyInteract>();
        
        var allKeys  = transform.GetComponentsInChildren<OnKeyInteract>();
        foreach (var key in allKeys)
        {
            if (key.keyType.Equals(OnKeyInteract.KeyType.black))
            {
                blackKeys.Add(key);
            }
            else
            {
                whiteKeys.Add(key);
            }
        }

        AssignAudioClipPitch();
    }


    private void AssignAudioClipPitch()
    {
        var allKeysCount = blackKeys.Count + whiteKeys.Count;
        var pitchRange = 2f;
        var pitchPerKey = pitchRange / allKeysCount;

        for (var i = 0; i < whiteKeys.Count; i++)
        {
            
        }
        
    }
}
