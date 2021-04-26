using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    public int score; 
    public int combo; 
    private double _timeHit;
    private int _pointMultiplier = 100;
    
    //the thresholds for note quality in ms
    private double _perfectTolerance = .05;
    private double _goodTolerance = .150;
    private double _perfectLowThreshold;    // = _perfectTolerance;
    private double _perfectHighThreshold;   // = Spawner.Instance.tempo - .100;
    private double _goodLowThreshold;       // = _goodTolerance;
    private double _goodHighThreshold;      // = Spawner.Instance.tempo - .150;
    
    public ParticleSystem explosion;// = this.gameObject.GetComponent<ParticleSystem>();

    private Vector3 _previousPos;
    // Start is called before the first frame update
    void Start()
    {
        score = UIScript.Instance.score;
        combo = UIScript.Instance.combo;
        _perfectHighThreshold = Spawner.Instance.tempo - _perfectTolerance;
        _perfectLowThreshold = _perfectTolerance;
        _goodHighThreshold = Spawner.Instance.tempo - _goodTolerance;
        _goodLowThreshold = _goodTolerance;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - _previousPos, -hit.transform.up) > 130)
            {
                //CHECK FOR TIME THE PLAYER IS HITTING THE NOTE
                
                //tracks time hit for accuracy
                //double hitTime = AudioSettings.dspTime;
                _timeHit = Spawner.Instance.timer;
                
                //play particle effect
                explosion.Play();
                //explosion.Play(transform.position = hit.transform.position);
                /*
                foreach (Transform child in hit.transform) 
                {
                    GameObject.Destroy(child.gameObject);
                    //child.parent = null;
                    //Destroy(hit.transform.root);
                    //DestroyImmediate(child.gameObject);
                    
                    
                    
                }*/
                //Destroy(hit.transform.parent.gameObject);
                Destroy(hit.transform.gameObject);
                //Destroy(transform.parent.gameObject);
                //hit.transform.GetComponent<on>()
                
                
                /*
                 * if note was hit within 100 ms of 0 , then accuracy = 150
                 * SWAP NUMBERS FOR VARIABLES
                 */


                
                
                //perfect hit
                if (_timeHit < _perfectLowThreshold || _timeHit > _perfectHighThreshold)
                {
                    _pointMultiplier = 150;
                    UIScript.Instance.lastNoteHit = 1; //perfect hit
                }
                
                //good hit
                else if (_timeHit < _goodLowThreshold || _timeHit > _goodHighThreshold)
                {
                    _pointMultiplier = 125;
                    UIScript.Instance.lastNoteHit = 2; //good hit
                }

                //regular hit
                else
                {
                    _pointMultiplier = 100;
                    UIScript.Instance.lastNoteHit = 3; //hit
                }
                
                // COMMENTED OUT AND MOVED TO NOTEHIT FUNCTION
                
                //increment score
                UIScript.Instance.combo++;
                if (UIScript.Instance.combo < 8)
                {
                    UIScript.Instance.score += _pointMultiplier * UIScript.Instance.combo;
                }
                //max combo 800 score
                else
                {
                    UIScript.Instance.score += _pointMultiplier * 8;
                }
                
                
            }
        }

        _previousPos = transform.position;
    }

    /*
    public void NoteHit()
    {
        //increment score
        UIScript.combo++;
        if (UIScript.combo < 8)
        {
            UIScript.score += 100 * UIScript.combo;
        }
        //max combo 800 score
        else
        {
            UIScript.score += 100 * 8;
        }
    }
    
    
    public void NormalHit()
    {
    
    }
    
    public void GoodHit()
    {
    
    }
    
    public void PerfectHit()
    {
    
    }
    */
}


