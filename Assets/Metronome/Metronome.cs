using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Metronome : MonoBehaviour
{
    public double bpm = 140.0F;
    public bool playMetronome = false;
    public TMPro.TextMeshProUGUI bpmDisplay;

    public TMPro.TMP_InputField bpmInputField;
    
    double nextTick = 0.0F; // The next tick in dspTime
    double sampleRate = 0.0F; 
    bool ticked = false;
    
    public delegate void PlayTickEvent();
    public event PlayTickEvent OnPlayTickEvent;
    
    public static Metronome instance;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            bpmDisplay.text = bpm.ToString();
            return;
        } 
        Destroy(this.gameObject);
        
    }

    void LateUpdate()
    {
        if (!playMetronome) return;
        if (!ticked && nextTick >= AudioSettings.dspTime ) {
            ticked = true;
            OnTick();
        }
    }

    // Just an example OnTick here
    void OnTick() {
        OnPlayTickEvent?.Invoke();
        //Debug.Log( "Tick" );
        // GetComponent<AudioSource>().Play();
    }

    void FixedUpdate() {
        if (!playMetronome) return;
        double timePerTick = 60.0f / bpm;
        double dspTime = AudioSettings.dspTime;

        while ( dspTime >= nextTick ) {
            ticked = false;
            nextTick += timePerTick;
        }
    }


    public void OnClickStart()
    {
        if (playMetronome)
        {
            playMetronome = false;
            return;
        }
        
        playMetronome = true;
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        nextTick = startTick + (60.0 / bpm);
    }

    public void OnInputBpmValueChange()
    {
        bpm = double.Parse(bpmInputField.text);
        bpmDisplay.text = bpm.ToString();
    }
}