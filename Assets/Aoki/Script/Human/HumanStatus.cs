using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 構造体がＵｎｉｔｙ上で映るようにする
[System.Serializable]
// 人と巨人のステータスに使う予定
public struct HumanStatus  {

    public HumanStatus( Color color )
    {
        this.color = color;
        hp = 1;
        attack = 1;
        CanBorn = false;
    }
    public Color color { get; set; }
    
    //public Material material { get; set; }

    public float hp { get; set; }
    public float attack { get; set; }
    public bool CanBorn { get; set; }

}
