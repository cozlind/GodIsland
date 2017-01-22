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
        /*
        if (col.tag == "human")
        {
            HumanMove humanMove = col.GetComponent<HumanMove>();
            humanMove.humanState = HumanMove.State.Attack;
            humanMove.aimEnemy = GameObject.Find("Black");
        }
         * */
    }
}
