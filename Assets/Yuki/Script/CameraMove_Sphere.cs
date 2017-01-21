using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_Sphere : MonoBehaviour {
    public GameObject gazeObj;
    public float minDistance = 3.0f;
    public float maxDistance = 10.0f;
    public float speed = 5.0f;
    public float rotateSpeed = 30;
    public float minYPos = 1.0f;
    private Vector3 mousePos;
    private float screenWidth;
    private float screenHeight;
    public float gazeMoveRange = 100;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = gazeObj.transform.position;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        UpdatePosition();
    }

    void Update()
    {
        UpdatePosition();
        CameraMove();
    }

    void UpdatePosition()
    {
        targetPos = gazeObj.transform.position;
    }

    void CameraMove()
    {
        mousePos = Input.mousePosition;

        if (mousePos.x <= gazeMoveRange && transform.position.y != 10)
        {
            gazeObj.transform.eulerAngles += new Vector3(0, rotateSpeed * Time.deltaTime, 0);
        }
        else if (mousePos.x >= screenWidth - gazeMoveRange && transform.position.y != 10)
        {
            gazeObj.transform.eulerAngles += new Vector3(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (mousePos.y >= screenHeight - gazeMoveRange && transform.rotation.eulerAngles.x < 80)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else if (mousePos.y <= gazeMoveRange && transform.position.y > minYPos)
        {
            transform.position += transform.up * -speed * Time.deltaTime;
        }
        

        if (Input.GetAxis("Vertical") > 0 &&  transform.rotation.eulerAngles.x < 80)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0 && transform.position.y > minYPos)
        {
            transform.position += transform.up * -speed * Time.deltaTime;
        }

        if (Input.GetAxis("Horizontal") > 0 && transform.position.y != 10)
        {
            gazeObj.transform.eulerAngles += new Vector3(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Horizontal") < 0 && transform.position.y != 10)
        {
            gazeObj.transform.eulerAngles += new Vector3(0, -rotateSpeed * Time.deltaTime, 0);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, minDistance))
        {

        }
        else 
        {
            if (scroll > 0)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }

        if (Vector3.Distance(targetPos, transform.position) < maxDistance && scroll < 0)
        {
            transform.position += transform.forward * -speed * Time.deltaTime;
        }

        transform.LookAt(targetPos);
    }
}
