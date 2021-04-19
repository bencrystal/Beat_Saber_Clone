using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    public int score = UIScript.score;
    public int combo = UIScript.combo;
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
                //play particle effect
                explosion.Play();
                //explosion.Play(transform.position = hit.transform.position);
                
                foreach (Transform child in transform) 
                {
                    child.parent = null;
                    //DestroyImmediate(child.gameObject);
                    
                    GameObject.Destroy(child.gameObject);
                    
                }
                Destroy(hit.transform.parent.gameObject);
                //Destroy(transform.parent.gameObject);
                //hit.transform.GetComponent<on>()
                
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
        }

        previousPos = transform.position;
    }
}
