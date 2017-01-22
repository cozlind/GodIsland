using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minDistance = 10;
    Vector3 offset;
    Vector3 PreMouseMPos;
    float zoomSpeed = 1000;
    void Update()
    {
        if (transform.position.y <= 0)
        {
            transform.position += new Vector3(0, -transform.position.y, 0);
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            float step = zoomSpeed * Time.deltaTime;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, minDistance))
            {

            }
            else
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0) transform.Translate(transform.forward * step * Input.GetAxis("Mouse ScrollWheel"), Space.World);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0) transform.Translate(transform.forward * step * Input.GetAxis("Mouse ScrollWheel"), Space.World);


        }
        if (Input.GetMouseButton(1))
        {
            if (PreMouseMPos.x == 0)
            {
                PreMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
            }
            else
            {
                Vector3 CurMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
                Vector3 offset = CurMouseMPos - PreMouseMPos;
                transform.Rotate(-offset.y * 0.08f,0,0,Space.Self);
                transform.Rotate(0, offset.x * 0.04f, 0, Space.World);
                PreMouseMPos = CurMouseMPos;
            }
        }
        else if (Input.GetMouseButton(2))
        {

            if (PreMouseMPos.x == 0)
            {
                PreMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
            }
            else
            {
                Vector3 CurMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
                Vector3 offset = CurMouseMPos - PreMouseMPos;
                offset = -offset * 0.04f;
                transform.Translate(offset);
                PreMouseMPos = CurMouseMPos;
            }
        }
        else
        {
            PreMouseMPos = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

}
