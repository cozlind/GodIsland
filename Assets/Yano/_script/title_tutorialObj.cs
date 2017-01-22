using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title_tutorialObj : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
            Destroy(this.gameObject);
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
