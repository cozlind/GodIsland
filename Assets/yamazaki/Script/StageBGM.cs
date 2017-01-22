using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBGM : MonoBehaviour {

    public AudioSource[] _AS = new AudioSource[3];
    public Transform _Giant;
    public GameObject _range;
    private RangeBGM _RangeBGM;
    private int _rand;

	// Use this for initialization
	void Start () {
        _AS[0].Play();
        _AS[1].Stop();
        _AS[2].Stop();
        _AS[1].volume = 0;
        _AS[2].volume = 0;
        _rand = Random.Range(1,3);
	}
	
	// Update is called once per frame
	void Update () {
        _RangeBGM = _range.GetComponent<RangeBGM>();
        if (_RangeBGM._BGM_flag == true && _AS[0].volume != 0)
        {
            _AS[0].volume -= Time.deltaTime / 2;
            _AS[_rand].Play();
            _AS[_rand].volume += Time.deltaTime / 2;
        }
    }
}
