using System.Collections;
using System.Collections.Generic;
using Beat;


using UnityEngine;

public class Spawner : Singleton<Spawner>
{

    //public Clock clock;

    public GameObject orientationCube;
    public GameObject[] cubes;
    public Transform[] points;  //points where cubes are instantiated
    //tempo of the song being played that the notes spawn to
    public double tempo = 127;  
    //offset on the timer to make spawns line up with the beat of the song
    public double offset = 0;   
    private double _spawnRate;

    //time tracker between 2 beats or spawns of the cube
    public double timer { get; private set; } 
    
    public AudioSource cameraAudioSource;

    //keeps track of making sure multiple blocks don't spawn in the same line
    private int oneAgo = -1;
    private int twoAgo = -1;
    private int spawnPoint = -1;


    private Renderer _backgroundColor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //initialize note spawn frequency, lower 120 for faster notes and raise for slower!
        _spawnRate = 1/(tempo / 120);

        //get background color to change to the beat
        _backgroundColor = orientationCube.GetComponent<Renderer>();


        //set spawn rate to tempo bpm
        //tempo = 60 / tempo;

        //initialize new clock at tempo bpm (should I set equal to a variable?
        //clock.SetBPM(tempo);
        //cameraAudioSource.PlayScheduled(clock.AtNextMeasure());
        //also start spawning


        //Clock.
        // Clock.BeatArgs(AtNextThirtySecond());
        //    Clock(AtNextThirtySecond())
        // cameraAudioSource.PlayScheduled(Clock.BeatEvent(AtNextThirtySecond()));

    }

    // Update is called once per frame
    void Update()
    {
        /*
        //if the audio isn't playing, play it
        if (!cameraAudioSource.isPlaying)
        {
            //cameraAudioSource.PlayScheduled(clock.AtNextMeasure());
            cameraAudioSource.Play();  
        }
        */
        
        
        if (timer + offset > _spawnRate) //&& Random.Range(0,9) < 6)
        {
            if (_backgroundColor.material.color == Color.gray)
            {
                _backgroundColor.material.SetColor("_EmissionColor", Color.black);
                _backgroundColor.material.SetColor("_Color", Color.black);
            }
            else
            {
                _backgroundColor.material.SetColor("_EmissionColor", Color.gray);
                _backgroundColor.material.SetColor("_Color", Color.gray);
            }
            
            while (spawnPoint == oneAgo || spawnPoint == twoAgo)
            {
                spawnPoint = Random.Range(0, 9);
            }
            //spawnPoint = Random.Range(0, 9);
            
            
            twoAgo = oneAgo;
            oneAgo = spawnPoint;
            
            //create a cube of red or blue randomly at one of the predefined locations
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[spawnPoint]);
            cube.transform.localPosition = Vector3.zero;
            //randomly facing 1 of 8 directions
            cube.transform.Rotate(transform.forward, 45 * Random.Range(0,8)); 
            //decrease the timer by the spawn rate threshold (reset)
            timer -= _spawnRate;
        }
        //increment the timer by the time since the last frame
        timer += Time.deltaTime;

        
    }
}
