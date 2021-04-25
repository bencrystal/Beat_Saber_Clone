using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    public int score = UIScript.score;
    public int combo = UIScript.combo;
    private double timeHit;
    private int pointMultiplier = 100;
    
    //the thresholds for note quality in ms
    private float perfectLowThreshold = .100;
    private float perfectHighThreshold = Spawner.Instance.tempo - .100;
    private float GoodLowThreshold = .150;
    private float GoodHighThreshold = Spawner.Instance.tempo - .150;
    
    public ParticleSystem explosion;// = this.gameObject.GetComponent<ParticleSystem>();

    private Vector3 previousPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - previousPos, -hit.transform.up) > 130)
            {
                //CHECK FOR TIME THE PLAYER IS HITTING THE NOTE
                
                //tracks time hit for accuracy
                //double hitTime = AudioSettings.dspTime;
                timeHit = Spawner.Instance.timer;
                
                //play particle effect
                explosion.Play();
                //explosion.Play(transform.position = hit.transform.position);
                
                foreach (Transform child in hit.transform) 
                {
                    GameObject.Destroy(child.gameObject);
                    child.parent = null;
                    //Destroy(hit.transform.root);
                    //DestroyImmediate(child.gameObject);
                    
                    
                    
                }
                Destroy(hit.transform.parent.gameObject);
                //Destroy(transform.parent.gameObject);
                //hit.transform.GetComponent<on>()
                
                
                /*
                 * if note was hit within 100 ms of 0 , then accuracy = 150
                 * SWAP NUMBERS FOR VARIABLES
                 */


                
                
                //perfect hit
                if (timeHit < perfectLowThreshold || timeHit > perfectHighThreshold)
                {
                    pointMultiplier = 150;
                }
                
                //good hit
                else if (timeHit < GoodLowThreshold || timeHit > GoodHighThreshold)
                {
                    pointMultiplier = 125;
                }

                //regular hit
                else
                {
                    pointMultiplier = 100;
                }
                
                // COMMENTED OUT AND MOVED TO NOTEHIT FUNCTION
                
                //increment score
                UIScript.combo++;
                if (UIScript.combo < 8)
                {
                    UIScript.score += pointMultiplier * UIScript.combo;
                }
                //max combo 800 score
                else
                {
                    UIScript.score += pointMultiplier * 8;
                }
                
                
            }
        }

        previousPos = transform.position;
    }


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
}


