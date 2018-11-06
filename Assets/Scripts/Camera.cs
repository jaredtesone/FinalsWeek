using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField]
    GameObject Player;
    public float speed = 0.5f;
	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, Player.transform.position.x, interpolation);
        position.y = Mathf.Lerp(transform.position.y, Player.transform.position.y+1, interpolation);
        position.z = Mathf.Lerp(transform.position.z, Player.transform.position.z, interpolation);
        transform.position = position;
    }
}
