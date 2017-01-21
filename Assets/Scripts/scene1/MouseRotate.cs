using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour {

    public Transform trail;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider != null)
        {
            Vector3 mouseCenter = new Vector3(hit.point.x, hit.point.y + 1, hit.point.z);
            trail.transform.localPosition.Set(0, 0, 4f);
            transform.Rotate(Vector3.up, 10);
            transform.position = mouseCenter;
        }
    }
}
