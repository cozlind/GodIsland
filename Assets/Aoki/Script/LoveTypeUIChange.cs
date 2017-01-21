using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveTypeUIChange : MonoBehaviour {

    public LoveWaveShot script;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onLove(  )
    {
        script.type = LoveType.Love; ;
    }
    public void onGlow()
    {
        script.type = LoveType.Glow;
    }

    public void onBroken()
    {
        script.type = LoveType.Broke;
    }
    public void onCreate()
    {
        script.type = LoveType.Create;
    }


}
