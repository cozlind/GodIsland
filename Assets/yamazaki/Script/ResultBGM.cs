using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBGM : MonoBehaviour {

    public AudioSource[] _AS;
    public bool _WinLose_flag;

	// Use this for initialization
	void Start () {
        //勝利判定を入れる
        if (_WinLose_flag == true)
        {
            _AS[0].Play();
        }
        else
        {
            _AS[1].Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (_AS[0].isPlaying == false && _AS[1].isPlaying == false && GetComponent<AudioSource>().isPlaying == false)
        {
             GetComponent<AudioSource>().Play();
        }
	}
}
