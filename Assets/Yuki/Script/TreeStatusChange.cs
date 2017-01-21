using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeStatusChange : MonoBehaviour {
    public float growTime = 3.0f;
    private float time;
    public Vector3 grownTreeSize;

    // Use this for initialization
    void Start()
    {
        time = growTime;
        grownTreeSize = transform.localScale;
        
        transform.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
    }

    // Update is called once per frame
    void Update()
    {
        Growing();
    }

    void Growing()
    {
        if (time >= 0)
        {
            transform.localScale += (grownTreeSize / growTime) * Time.deltaTime;
            time -= Time.deltaTime;
        }
    }
}
