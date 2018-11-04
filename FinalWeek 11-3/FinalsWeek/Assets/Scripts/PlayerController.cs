using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //private Rigidbody rb;
    public float speed;
    public float timeChange;
    public float rotateSpeed;
    public float cw;
    public float ccw;
    Vector3 movement;
    Vector3 facing;
    //public Transform player;
       
    private void Start() {
        //rb = GetComponent<Rigidbody>();
        facing = transform.forward;
    }
    
    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveVertical > 0)
            movement = transform.forward;
        else if (moveVertical < 0)
            movement = -transform.forward;
        else
            movement = Vector3.zero;

        //if (moveHorizontal > 0)             //turn right
        //    facing += transform.right;
        //else if (moveHorizontal < 0)        //turn left
        //    facing -= transform.right;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(facing), Time.deltaTime * rotateSpeed);

        if (moveHorizontal > 0) {
            //turn right (clockwise)
            transform.Rotate(0, Time.deltaTime * cw, 0);
        } else if (moveHorizontal < 0) {
            //turn left (counterclockwise)
            transform.Rotate(0, Time.deltaTime * ccw, 0);
        }

        //move forward or backward
        if (moveVertical != 0)
            transform.Translate(movement * speed * Time.deltaTime, Space.World);

       // rb.velocity = Vector3.Lerp(rb.velocity, speed * movement, timeChange * Time.deltaTime);

        
    }

}
