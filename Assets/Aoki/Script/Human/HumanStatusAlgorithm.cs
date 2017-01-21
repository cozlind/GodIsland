using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStatusAlgorithm {

	public static float GetAttackPersent( HumanStatus status )
    {
        return GetSimpleStrength( status );
    }

    public static float GetBornHpPersent(HumanStatus status)
    {
        return GetSimpleStrength(status);
    }

    /// 白に近いほど１、黒に近いほど０を返す
    private static float GetSimpleStrength( HumanStatus status )
    {
        float attack = 0;
        Color color = status.color;

        attack = (color.r + color.g + color.b) / 3.0f;
        
        return attack;
    }

  

}
