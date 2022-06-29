using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GetBPM : MonoBehaviour
{
    [SerializeField] private float  angle;
    [SerializeField] private float  rotation;
    [SerializeField] private Image fill;
    [SerializeField] private Text valText;

    [SerializeField] private int maxAngle;

    private int _angleRound = 0;

    private int _startValue = 50;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        rotation = this.transform.rotation.z * Mathf.Rad2Deg - 39 ;
        angle = this.transform.rotation.z * Mathf.Rad2Deg - 39 ;
        
        angle = angle < 0 ? angle * -1 : angle;
        
        _angleRound = (int)angle;
        
        fill.fillAmount = ((_angleRound/ 0.4f)/ maxAngle) + 0.014f;
        valText.text = ((int)(_angleRound/ 0.4f ) + _startValue).ToString(CultureInfo.InvariantCulture);
        Metronome.instance.bpm = (int)(_angleRound/ 0.4f )+ _startValue;
        Metronome.instance.bpmDisplay.text = ((int)(_angleRound/ 0.4f )+ _startValue).ToString();
    }

    private void Exit()
    {
        Metronome.instance.bpm = _angleRound != 0? _angleRound: Metronome.instance.bpm;
    }
}

/*
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//public class OnKeyInteract : UnityEngine.XR.Interaction.Toolkit.XRSimpleInteractable
public class CircleSlider: MonoBehaviour
{
    [SerializeField] private Transform handle;
    [SerializeField] private Image fill;
    [SerializeField] private Text valText;
    private Vector3 mousePos;

    public float r;
    
    // Update is called once per frame
    public void OnHandelDrag()
    {
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg ;
        angle = (angle <= 0) ? (360 + angle) : angle;
        if (angle<=225 || angle>=315)
        {
            Quaternion r = Quaternion.AngleAxis( angle + 135f, Vector3.forward);
            handle.rotation = r;
            angle = ((angle >= 315) ? (angle - 360) : angle) + 45;
            fill.fillAmount = 0.75f - (angle / 360f); 
            valText.text = Mathf.Round((fill.fillAmount * 100) / 0.75f).ToString(CultureInfo.InvariantCulture);
        }
    }
}
*/
