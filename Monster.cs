using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    [SerializeField]
    GameObject Player;

    Player player;
    Rigidbody rb;
    float ImpulseForceMagnitude =2;

	// Use this for initialization
	void Start () {
        player = Player.GetComponent<Player>();
        rb = GetComponent<Rigidbody>();


	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = new Vector3(Player.transform.position.x - transform.position.x,
                                      Player.transform.position.y - transform.position.y,
                                      Player.transform.position.z - transform.position.z);
        direction.Normalize();
        rb.AddForce(ImpulseForceMagnitude * direction, ForceMode.Impulse);
	}
}
