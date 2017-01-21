using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ave : MonoBehaviour {

    private Color _while_color = new Color(0,0,0,0);
    private Vector3[] _vec = new Vector3[2];
    public List<Color> _color = new List<Color>();
    private bool _stay_flag = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("human"))
        {
            _color.Add(col.gameObject.GetComponent<MeshRenderer>().material.color);
        }
    }

    void OnTriggerStay()
    {
        _stay_flag = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (_stay_flag == true)
        {
            _while_color = average.ColorAverage(_color);
            Debug.Log(_while_color);
            _stay_flag = false;
            _color.Clear();
        }
    }
}
