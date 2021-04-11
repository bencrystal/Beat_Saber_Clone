using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60/105)*2;
    private float _timer;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > beat)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 45 * Random.Range(0,8)); //random 1 of 8 cardinal directions
            _timer -= beat;
        }

        _timer += Time.deltaTime;
    }
}
