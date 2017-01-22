using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantGodBeam : MonoBehaviour {
    public BlackGiant blackGiant;
    public SearchCharacter searchCharacter;
	// Use this for initialization
	void Start () {
        //blackGiant = GameObject.Find("Black").GetComponent<BlackGiant>();
        //searchCharacter = GameObject.Find("BlackInSearchRangeSphere").GetComponent<SearchCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "human")
        {

            blackGiant.aimHuman = null;
            searchCharacter.aimHuman = null;
        }
    }
}
