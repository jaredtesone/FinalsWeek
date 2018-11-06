using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour {
    [SerializeField]
    GameObject Player;
  
    NavMeshAgent navMeshAgent;
    public float speed = 3.5f;
    public float acceleration =8;
    public float stoppingDistance=0.2f;
    public float angularSpeed =120;

    bool followPlayer = false;

	// Use this for initialization
	void Start () {
 
        navMeshAgent = GetComponent<NavMeshAgent>();




	}
	
	// Update is called once per frame
	void Update () {
        navMeshAgent.speed = speed;
        navMeshAgent.acceleration = acceleration;
        navMeshAgent.stoppingDistance = stoppingDistance;
        navMeshAgent.angularSpeed = angularSpeed;




        if (followPlayer == true)
        {
            navMeshAgent.destination = Player.transform.position;
          
        }

        else if (followPlayer == false)
        {
            //or put it in a random place depend on the level design

            navMeshAgent.destination = new Vector3(0,0,0);
        }
	}

    void OnTriggerEnter(Collider other)
    { if(other.gameObject.tag == "Player")
        {
           // followPlayer = true;
            print("in");
        }

        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            followPlayer =false;
            print("out");
        }


    }
}
