using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delight : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("delight", true);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
