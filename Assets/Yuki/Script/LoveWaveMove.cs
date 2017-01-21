using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveWaveMove : MonoBehaviour {
    public float speed = 10.0f;
    public GameObject loveField;
    private Vector3 FieldPos;
    LoveWaveShot loveWaveShot;
	// Use this for initialization
	void Start () {
        loveWaveShot = GameObject.Find("ClickManager").GetComponent<LoveWaveShot>();
        FieldPos = loveWaveShot.hitPoint;
        transform.LookAt(FieldPos);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.logger.Log( col.name );
        if (col.gameObject.tag == "Ground")
        {
            Instantiate(loveField, FieldPos, Quaternion.EulerAngles(0, 0, 0));
            Destroy(gameObject);
        }
    }
}
