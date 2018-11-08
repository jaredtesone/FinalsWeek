﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    //[SerializeField]
    public GameObject Player;

    bool lookAt = true;
 
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - Player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Player.transform.position + offset;
        //transform.rotation = Player.transform.rotation;

        //if (lookAt)
        //{
        //    transform.LookAt(Player.transform);
        //}
        //else
        //{
        //  //  transform.rotation = Player.transform.rotation;
        //}
    }
}