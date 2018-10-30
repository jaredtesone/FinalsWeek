using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public int forceMult = 5;
       
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate() {
        /*if ((Input.GetKey("w") || Input.GetKey("up")) && (Input.GetKey("s") || Input.GetKey("down"))) {
          rb.AddForce(Vector3.zero);
        }*/
        if (Input.GetKey("w") || Input.GetKey("up")){
            //move forward
            rb.AddForce(5*Vector3.forward);
        }

        if (Input.GetKey("s") || Input.GetKey("down")){
            //move back
            rb.AddForce(5*Vector3.back);
        }

        if (Input.GetKey("a") || Input.GetKey("left")){
            //move left
            rb.AddForce(5*Vector3.left);
        }  
        
        if (Input.GetKey("d") || Input.GetKey("right")){
            //move right
            rb.AddForce(5*Vector3.right);
        }
    }

}
