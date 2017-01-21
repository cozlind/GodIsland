using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_Sphere : MonoBehaviour {
    public GameObject gazeObj;
    public float distance = 10.0f;
    public float speed = 5.0f;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = gazeObj.transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0 && transform.rotation.x > 0)
        {
            transform.position += transform.up * -speed * Time.deltaTime;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += transform.right * -speed * Time.deltaTime;
        }
        transform.LookAt(targetPos);
    }
}
