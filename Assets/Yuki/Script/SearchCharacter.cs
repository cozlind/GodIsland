using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour {

    public GameObject aimHuman;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider col)
    {
        if (aimHuman == null && col.tag == "human")
        {
            aimHuman = col.gameObject;
        }
        
        if (col.tag == "human")
        {
            Unit unit = col.GetComponent<Unit>();
            unit.buttle = true;
            unit.aimEnemy = GameObject.Find("Black");
        }
         
    }
}
