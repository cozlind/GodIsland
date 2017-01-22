using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aori : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //MainCameraの中のResultBGMスクリプトから勝利か判定
        if (GameObject.Find("ResultBGM").GetComponent<ResultBGM>()._WinLose_flag == false)
        {
            if (gameObject.GetComponent<Animator>().speed < 10)
            {
                gameObject.GetComponent<Animator>().speed += Time.deltaTime / 2;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
