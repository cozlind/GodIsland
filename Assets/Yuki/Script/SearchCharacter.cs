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

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("aaa");
        if (aimHuman == null && col.tag == "human")
        {
            Debug.Log("( *´艸｀)");
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
