using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStatusAlgorithm: MonoBehaviour {
    /*
    static float MaxAttack = 100;
    static float MaxHp = 10000;

    static float MinAttack = 1;
    static float MinHp = 1;

    public static float GetAttack( Color color )
    {
        return Mathf.Lerp( MinAttack, MaxAttack, GetSimpleStrength(color));
    }

    public static float GetBornHp(Color color)
    {
        return Mathf.Lerp(MinHp, MaxHp, GetSimpleStrength(color));
    }
    */
    public static float GetAttackPersent(Color color)
    {
        return GetSimpleStrength(color);
    }

    public static float GetBornHpPersent(Color color)
    {
        return GetSimpleStrength(color);
    }
    /// 白に近いほど１、黒に近いほど０を返す
    private static float GetSimpleStrength(Color color)
    {
        float attack = 0;

        attack = (color.r + color.g + color.b) / 3.0f;
        
        return attack;
    }

  

}
