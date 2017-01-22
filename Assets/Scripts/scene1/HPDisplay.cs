using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour {
    public Image hpbar;
    public GiantHP giantHpScript;
	
    public void Update()
    {
        hpbar.fillAmount = giantHpScript.HP / 50f;
    }
}
