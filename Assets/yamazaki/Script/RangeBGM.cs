using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBGM : MonoBehaviour {

    public GameObject _Giant;
    public bool _BGM_flag = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_BGM_flag == false)
        {
            transform.position = _Giant.transform.position;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("human"))
        {
            _BGM_flag = true;
        }
    }
}
