using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHuman : MonoBehaviour {

    [SerializeField]
    HumanStatus _status = new HumanStatus();

    [SerializeField]
    Color _currentColor = new Color();

	// Use this for initialization
	public void init  (HumanStatus status) {
        _status = status;
        _currentColor = _status.color;
        Material m = GetComponent<MeshRenderer>().material;
        m.SetColor("_Color", _status.color);
    }
	
    public HumanStatus GetStatus()
    {
        return _status;
    }

    public Color GetColor()
    {
        return _currentColor;
    }

	// Update is called once per frame
	void Update () {
	}
}
