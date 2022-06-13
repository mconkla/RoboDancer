using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKnob : MonoBehaviour
{
    [SerializeField] public GameObject Knob;
    // Start is called before the first frame update

    public void Open() 
    {
        if (Knob != null)
        {
            bool isActive = Knob.activeSelf;
            if (isActive)
            {
                Knob.SetActive(false);
            }
            else
            {
                Knob.SetActive(true);
            }
          
        }
    }
}
