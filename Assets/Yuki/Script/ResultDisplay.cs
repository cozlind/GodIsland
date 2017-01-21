using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour {

    Text surviveHumansText;
    Text deadHumansText;
    Text birthHumansText;
	// Use this for initialization
	void Start () {
        surviveHumansText = GameObject.Find("SurviveHumansText").GetComponent<Text>();
        deadHumansText = GameObject.Find("DeadHumansText").GetComponent<Text>();
        birthHumansText = GameObject.Find("BirthHumansText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        surviveHumansText.text = "SurviveHumans:" + ResultManager.allHumansNum;
        deadHumansText.text = "DeadHumans:" + ResultManager.deadHumansNum;
        birthHumansText.text = "BirthHumans:" + ResultManager.birthHumansNum;
	}
}
