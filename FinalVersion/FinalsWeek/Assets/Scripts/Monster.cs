using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Monster : MonoBehaviour {
    [SerializeField]
    GameObject Player;
  
    public float speed = 3.5f;
    public float acceleration = 8;
    public float stoppingDistance = 0.2f;
    public float angularSpeed = 120;

    private Vector3[] points = new Vector3[8];
    private int destPoint = -1;
    private System.Random rand = new System.Random();
    private NavMeshAgent navMeshAgent;
    private Vector3 defaultRotation = new Vector3(0, 0, -90);
    private Quaternion orientation = new Quaternion();


    bool followPlayer = false;
    Animator m_Animator;

    // Use this for initialization
    void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();

        //set initial rotation
        //orientation.eulerAngles = defaultRotation;
        //transform.rotation = orientation;

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the navMeshAgent doesn't slow down as it
        // approaches a destination point).
        navMeshAgent.autoBraking = false;

        //initialize points array
        points[0] = new Vector3(-17.7f, 0, 4.5f);
        points[1] = new Vector3(2, 0, 7.3f);
        points[2] = new Vector3(-1.5f, 0, -20.7f);
        points[3] = new Vector3(-19, 0, -18);
        points[4] = new Vector3(-17.5f, 0, -8.8f);
        points[5] = new Vector3(-30, 0, 0.2f);
        points[6] = new Vector3(-25.7f, 0, 23.3f);
        points[7] = new Vector3(-3.6f, 0, 18);

        GotoNextPoint();



    }
	
	// Update is called once per frame
	void Update () {
        navMeshAgent.speed = speed;
        navMeshAgent.acceleration = acceleration;
        navMeshAgent.stoppingDistance = stoppingDistance;
        navMeshAgent.angularSpeed = angularSpeed;

        //Debug.Log(followPlayer);
        if (followPlayer == true)
        {
            //Debug.Log("follow");
            navMeshAgent.destination = Player.transform.position;
        }

        else if (followPlayer == false)
        {
            // Choose the next destination point when the navMeshAgent gets
            // close to the current one.
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

        //if (!navMeshAgent.isStopped)
        //{
        //    //var targetPosition = navMeshAgent.pathEndPosition;
        //    //var targetPoint = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        //    //var _direction = (targetPoint - transform.position);
        //    //Debug.Log(_direction);
        //    //transform.rotation = Quaternion.LookRotation(_direction);

        m_Animator.SetTrigger("Walk");

        //    //transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, 360);
        //} else
        //{
        //    m_Animator.SetTrigger("Stop");
        //}
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        //randomly select next destination point
        int nextPoint = rand.Next(points.Length);
        while (nextPoint == destPoint)
            nextPoint = rand.Next(points.Length);
        destPoint = nextPoint;

        // Set the navMeshAgent to go to the currently selected destination.
        navMeshAgent.destination = points[destPoint];

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        //destPoint = (destPoint + 1) % points.Length;
    }

    void OnTriggerEnter(Collider other)
    { if(other.gameObject.tag == "Player")
        {
            followPlayer = true;
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
