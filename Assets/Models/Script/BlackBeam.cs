using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBeam : MonoBehaviour {
    public Animator beam;

	public void BeamShot () {
        beam.Play("Beam");
	}
}
