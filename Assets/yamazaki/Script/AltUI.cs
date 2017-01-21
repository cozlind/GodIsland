using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltUI : MonoBehaviour {

    public Sprite _morido, _sakudo;
    private Image _im;

	// Use this for initialization
	void Start () {
        _im = GetComponent<Image>();
        _im.sprite = _morido;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftAlt) && _im.sprite == _morido)
        {
            _im.sprite = _sakudo;
        }
        else if(Input.GetKeyUp(KeyCode.LeftAlt) && _im.sprite == _sakudo)
        {
            _im.sprite = _morido;
        }
    }
}
