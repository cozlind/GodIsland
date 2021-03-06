﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveWaveMove : MonoBehaviour {
    public float speed = 10.0f;
    public GameObject loveField;
    private Vector3 FieldPos;
    LoveWaveShot loveWaveShot;

    public LoveType type;

    TreeManager treeManager;

    // Use this for initialization
    void Start () {
        loveWaveShot = GameObject.Find("ClickManager").GetComponent<LoveWaveShot>();
        FieldPos = loveWaveShot.hitPoint;
        transform.LookAt(FieldPos);
        treeManager = GameObject.FindObjectOfType<TreeManager>();

    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (type == LoveType.Glow)
            {

                //Instantiate(TreePrefab, FieldPos, TreePrefab.transform.rotation);
                treeManager.AddTree( FieldPos, Quaternion.identity );
            }
            else if( type == LoveType.Love )
            {
                FieldPos.y += 1;
                Instantiate(loveField, FieldPos, Quaternion.Euler(0, 0, 0));
                
            }
            Destroy(gameObject);
        }
    }
}
