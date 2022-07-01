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
    [SerializeField] private TMPro.TextMeshProUGUI valText;

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

