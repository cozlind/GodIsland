using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 構造体がＵｎｉｔｙ上で映るようにする
[System.Serializable]
public struct HumanStatus  {

    public Color color { get; set; }

    public Material material { get; set; }

    public float hp { get; set; }
    public float attack { get; set; }
    public bool CanBorn { get; set; }

}
