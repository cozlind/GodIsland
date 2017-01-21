using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour {
    static public int allHumanNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void CountAllhumans()
    {
        GameObject[] humans = GameObject.FindGameObjectsWithTag("human");
        foreach (GameObject obj in humans)
        {
            allHumanNum++;
        }
    }

    void CountDeadhumans()
    {

    }
}
