using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public int humanNum;

    GameObject[] humans;
    HumanManager humanManager;
    SceneLoadManager sceneLoadManager;
	// Use this for initialization
	void Start () {
        humanManager = GameObject.Find("HumanManager").GetComponent<HumanManager>();
        sceneLoadManager = GetComponent<SceneLoadManager>();
	}
	
	// Update is called once per frame
	void Update () {
        humanNum = 0;
        humans = GameObject.FindGameObjectsWithTag("human");
        foreach (GameObject obj in humans)
        {
            humanNum++;
        }

        if (humanNum <= 0)
        {
            sceneLoadManager.enabled = true;
            ResultData.Instance.createHuman = humanManager.GetHumanCreateCount();
            ResultData.Instance.AliveHuman = humanManager.GetHumanAliveCount();

            ResultData.Instance.deadHuman = humanManager.GetHumanCreateCount()- humanManager.GetHumanAliveCount();
        }
    }
}
