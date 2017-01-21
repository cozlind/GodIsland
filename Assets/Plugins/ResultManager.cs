using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour {
    static public int allHumansNum;
    static public int deadHumansNum;
    static public int birthHumansNum;
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
            allHumansNum++;
        }
    }
}
