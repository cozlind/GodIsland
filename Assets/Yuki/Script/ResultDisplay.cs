using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour {

    Text surviveHumansText;
    Text DeadHumansText;
    Text BirthHumansText;
	// Use this for initialization
	void Start () {
        surviveHumansText = GameObject.Find("SurviveHumansText").GetComponent<Text>();
        DeadHumansText = GameObject.Find("DeadHumansText").GetComponent<Text>();
        BirthHumansText = GameObject.Find("BirthHumansText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        surviveHumansText.text = "SurviveHumans:" + ResultManager.allHumansNum;
        BirthHumansText.text = "BirthHumans:" + ResultManager.birthHumansNum;
	}
}
