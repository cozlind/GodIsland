using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTree : MonoBehaviour
{
    int cnt = 0;
    public GameObject tree;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt == 120)
            Instantiate(tree,new Vector3(0f,1f,-5f),Quaternion.identity);
        cnt++;
    }
}
