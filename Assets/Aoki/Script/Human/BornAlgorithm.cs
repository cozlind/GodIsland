using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornAlgorithm : MonoBehaviour {

    //[SerializeField]
    //List<HumanStatus> humans;
    public static Color GetBornColor(Color color1, Color color2)
    {
        Color color = Color.white;
        color = color1 + color2;
        color.r = Mathf.Clamp(color.r, 0, 1);
        color.g = Mathf.Clamp(color.g, 0, 1);
        color.b = Mathf.Clamp(color.b, 0, 1);
        return color;
    }

    public static HumanStatus GetBornAddStatus( HumanStatus status1, HumanStatus status2 )
    {
        HumanStatus humanStatus_ = new HumanStatus();

        Color color_ = Color.white ;
        color_ = GetBornColor( status1.color, status2.color );

        humanStatus_.color = color_;

        humanStatus_.attack = HumanStatusAlgorithm.GetAttackPersent( humanStatus_.color );
        humanStatus_.hp = HumanStatusAlgorithm.GetBornHpPersent( humanStatus_.color );


        return humanStatus_;
    }

}
