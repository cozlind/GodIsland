﻿using System.Collections;
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
            HumanAttackCtrl humanAttackCtrl = col.transform.FindChild("HumanBaseModel").GetComponent<HumanAttackCtrl>();
            humanAttackCtrl.battle = true;
            humanAttackCtrl.aimEnemy = GameObject.Find("Black");
        }
         
    }
}
