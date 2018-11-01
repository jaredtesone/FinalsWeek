using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed = 3;
    public float timeChange = 10;
    //public Transform player;
       
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // //move according to input
        //rb.AddForce(speed * movement);
        //Vector3 desiredDirection = transform.position - player.transform.position;
        rb.velocity = Vector3.Lerp(rb.velocity, speed * movement, timeChange * Time.deltaTime);

        //if (Input.GetKey("w") || Input.GetKey("up"))
        //{
        //    //move forward
        //    rb.AddForce(5 * Vector3.forward);
        //}

        //if (Input.GetKey("s") || Input.GetKey("down"))
        //{
        //    //move back
        //    rb.AddForce(5 * Vector3.back);
        //}

        //if (Input.GetKey("a") || Input.GetKey("left"))
        //{
        //    //move left
        //    rb.AddForce(5 * Vector3.left);
        //}

        //if (Input.GetKey("d") || Input.GetKey("right"))
        //{
        //    //move right
        //    rb.AddForce(5 * Vector3.right);
        //}
    }

}
