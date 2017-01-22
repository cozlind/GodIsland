using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBeam : MonoBehaviour {
    public Animator beam;
    public AudioSource _AS;

	public void BeamShot () {
        beam.Play("Beam");
        _AS.Play();
	}
}
