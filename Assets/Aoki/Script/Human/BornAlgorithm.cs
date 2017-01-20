using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornAlgorithm : MonoBehaviour {

    //[SerializeField]
    //List<HumanStatus> humans;



    public static HumanStatus GetBornAddStatus( HumanStatus status1, HumanStatus status2 )
    {
        HumanStatus humanStatus_ = new HumanStatus();

        Color color_ = Color.white ;
        color_ = status1.color + status2.color;
        color_.r = Mathf.Clamp(color_.r, 0, 1);
        color_.g = Mathf.Clamp(color_.g, 0, 1);
        color_.b = Mathf.Clamp(color_.b, 0, 1);

        humanStatus_.color = color_;
        
        return humanStatus_;
    }

}
