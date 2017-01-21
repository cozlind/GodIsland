using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAverage : MonoBehaviour {
    public static Color ColorAverage(GameObject[] humans)
    {
        Color while_color = new Color(0, 0, 0, 0);
        /*for (int a = 0; a < color.Count; a++)
        {
            while_color += color[a] / color.Count;
        }*/

        Color[] colors = new Color[humans.Length];

        for (int i = 0; i < humans.Length; i++)
        {
           colors[i] = humans[i].GetComponent<MeshRenderer>().material.color;
        }
        //while_color = (colors[0] + colors[1]) / 2;
        while_color = colors[0] + colors[1];
        return while_color;
    }
}
