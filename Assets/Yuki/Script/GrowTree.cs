using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour {
    public GameObject tree;
    [HideInInspector]
    public Vector3 hitPoint;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        MouseClick();
    }

    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject == null)
                {
                    return;
                }
                // hitした位置を格納する
                if (hit.collider.gameObject.tag == "Ground")
                {
                    hitPoint = hit.point;
                    Instantiate(tree, hitPoint, Quaternion.Euler(0, 0, 0));
                }
            }
            else
            {
                return;
            }
        }
    }
}
