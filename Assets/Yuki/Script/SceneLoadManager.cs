﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour {

    public void SceneLoad(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void HumansCount()
    {
        GameObject[] humans = GameObject.FindGameObjectsWithTag("human");
        foreach (GameObject obj in humans)
        {
            ResultManager.allHumansNum++;
        }
    }
}
