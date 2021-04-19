using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    //public int combo = UIScript.combo;
    public int speed = 2;

    //instantiated value to see
    //public bool wasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += -transform.forward * (speed * Time.deltaTime)  ;

        //once block is not destroyed and is behind player, reset combo
        if (transform.position.z < -1) // && transform != null) //gameObject != null) 
        {
            
            foreach (Transform child in transform) 
            {
                child.parent = null;
                GameObject.Destroy(child.gameObject);
                
            }
            Destroy(transform.parent.gameObject);
            Destroy(transform.gameObject);

            //end combo
            UIScript.combo = 0;
            
            /*
            if (wasHit == false)
            {
                UIScript.combo = 0;
            }
            */
        }
    }
}
