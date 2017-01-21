using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamehamehaMove : MonoBehaviour {
    public int power = 40;
    public float speed = 10;
    float time = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;

        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Black")
        {
            col.gameObject.SendMessage("damage", power);
            Destroy(gameObject);
        }
    }
}
