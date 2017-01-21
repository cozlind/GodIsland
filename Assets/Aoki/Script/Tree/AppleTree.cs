using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    float timer = 0;
    [SerializeField]
    float aliveTime = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if( timer > aliveTime )
        {
            Destroy( this.gameObject );
        }
		
	}
}
