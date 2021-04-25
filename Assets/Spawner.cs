using System.Collections;
using System.Collections.Generic;
using Beat;


using UnityEngine;

public class Spawner : Singleton<Spawner>
{

    public Clock clock;
    
    public GameObject[] cubes;
    public Transform[] points; //points where cubes are instantiated
    public float tempo = 127; //(60/105)*2;
    
    public float timer { get; private set; } //time between 2 beats or spawns of the cube
    
    public AudioSource cameraAudioSource;

    //keeps track of making sure multiple blocks don't spawn in the same line
    private int oneAgo = -1;
    private int twoAgo = -1;
    private int spawnPoint = -1;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        //note frequency
        
        //set spawn rate to tempo bpm
        //tempo = 60 / tempo;
        
        //initialize new clock at tempo bpm (should I set equal to a variable?
        clock.SetBPM(tempo);
        cameraAudioSource.PlayScheduled(clock.AtNextMeasure());
        //also start spawning
        
        
        //Clock.
       // Clock.BeatArgs(AtNextThirtySecond());
        //    Clock(AtNextThirtySecond())
       // cameraAudioSource.PlayScheduled(Clock.BeatEvent(AtNextThirtySecond()));

    }

    // Update is called once per frame
    void Update()
    {

        if (!cameraAudioSource.isPlaying)
        {
            //cameraAudioSource.PlayScheduled(clock.AtNextMeasure());
            cameraAudioSource.Play();
            
        }
        
        
        
        if (timer > tempo)
        {
            while (spawnPoint == oneAgo || spawnPoint == twoAgo)
            {
                spawnPoint = Random.Range(0, 9);
            }

            twoAgo = oneAgo;
            oneAgo = spawnPoint;
            
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[spawnPoint]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 45 * Random.Range(0,8)); //random 1 of 8 cardinal directions
            timer -= tempo;
        }

        timer += Time.deltaTime;
    }
}
