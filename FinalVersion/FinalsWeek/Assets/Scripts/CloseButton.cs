﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


  public void OnClick(){

        GameObject clue = GameObject.FindWithTag("Clue");
        if (clue!=null)
        {
            Destroy(clue);
        }
    }
}



