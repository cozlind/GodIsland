using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    private Transform God;
    public float BallSpeed;

	// Use this for initialization
	void Start () {
        God = GameObject.Find("Giant").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(God.position);
        transform.position += transform.forward * BallSpeed;
	}
}
