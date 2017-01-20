using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornAlgorithm : MonoBehaviour {

    //[SerializeField]
    //List<HumanStatus> humans;

    public static HumanStatus GetBornStatus( HumanStatus status1, HumanStatus status2 )
    {
        HumanStatus humanStatus = new HumanStatus();

        Color color = Color.white ;

        color = status1.color + status2.color;
        


        return humanStatus;
    }

}
