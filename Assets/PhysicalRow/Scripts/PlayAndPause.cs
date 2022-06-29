using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayAndPause : MonoBehaviour
{
    public static PlayAndPause instance;
    [SerializeField] public bool play = false;

    [SerializeField] public Material playMaterial;
    [SerializeField] public Material pauseMaterial;
    [SerializeField] private Renderer materialRenderer;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            play = false;
            return;
        }
    }

    // Update is called once per frame
    public void OnClickStart()
    {
        if (play)
        {
            play = false;
            materialRenderer.material = playMaterial;
        }
        else
        {
            play = true;
            materialRenderer.material = pauseMaterial;
        }
    }
}
