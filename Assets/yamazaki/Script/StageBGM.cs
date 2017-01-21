using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBGM : MonoBehaviour {

    public AudioSource[] _AS = new AudioSource[3];
    public Transform _point, _Giant;

    public float _dist_min,_dist_cen, _dist_max;
    private float _while_dist;

	// Use this for initialization
	void Start () {
        _AS[0].volume = 1;
        _AS[1].volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
        _while_dist = Vector3.Distance(_point.position, _Giant.position);

        /*if (_while_dist >= _dist_min && _while_dist <= _dist_cen)
        {
            _AS[1].volume = _while_dist / _dist_min - 1;
            _AS[2].volume = 1 - (_while_dist / _dist_min - 1);
        }
        if (_while_dist < _dist_min)
        {
            _AS[1].volume = 0;
            _AS[2].volume = 1;
        }
        if (_while_dist > _dist_cen)
        {
            _AS[1].volume = 1;
            _AS[2].volume = 0;
        }
        if (_while_dist >= _dist_cen && _while_dist <= _dist_max)
        {
            _AS[0].volume = _while_dist / _dist_cen - 1;
            _AS[1].volume = 1 - (_while_dist / _dist_cen - 1);
        }
        if (_while_dist < _dist_cen)
        {
            _AS[0].volume = 0;
            _AS[1].volume = 1;
        }
        if (_while_dist > _dist_max)
        {
            _AS[0].volume = 1;
            _AS[1].volume = 0;
        }*/

        if (_while_dist >= _dist_max)
        {
            _AS[0].volume = 1;
            _AS[1].volume = 0;
        }
        if (_while_dist >= (_dist_max + _dist_cen) /2 && _while_dist <= _dist_max)
        {
            _AS[0].volume = (_while_dist / _dist_cen - 1) / 2;
            _AS[1].volume = (1 - (_while_dist / _dist_cen - 1)) * 2;
        }
        if (_while_dist >= (_dist_cen + _dist_min) / 2 && _while_dist <= (_dist_max + _dist_cen) / 2)
        {
            _AS[0].volume = 0;
            _AS[1].volume = 1;
            _AS[2].volume = 0;
        }
        if (_while_dist <= (_dist_cen + _dist_min) / 2 && _while_dist >= _dist_min)
        {
            _AS[1].volume = (_while_dist / _dist_min - 1) * 2;
            _AS[2].volume = (1 - (_while_dist / _dist_min - 1)) /2;

        }
        if (_while_dist <= _dist_min)
        {
            _AS[1].volume = 0;
            _AS[2].volume = 1;
        }
    }
}
