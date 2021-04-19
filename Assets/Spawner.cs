﻿using System.Collections;
using System.Collections.Generic;
using Beat;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] cubes;
    public Transform[] points; //points where cubes are instantiated
    public float tempo = 127; //(60/105)*2;
    
    private float _timer; //time between 2 beats or spawns of the cube

    public AudioSource cameraAudioSource;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //note frequency
        
        //set spawn rate to tempo bpm
        //tempo = 60 / tempo;
        
        //initialize new clock at tempo bpm (should I set equal to a variable?
        //Clock.Instance.SetBPM(tempo);
        //cameraAudioSource.PlayScheduled(Clock(AtNextThirtySecond()));
        //Clock.
       // Clock.BeatArgs(AtNextThirtySecond());
        //    Clock(AtNextThirtySecond())
       // cameraAudioSource.PlayScheduled(Clock.BeatEvent(AtNextThirtySecond()));

    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > tempo)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 9)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 45 * Random.Range(0,8)); //random 1 of 8 cardinal directions
            _timer -= tempo;
        }

        _timer += Time.deltaTime;
    }
}
