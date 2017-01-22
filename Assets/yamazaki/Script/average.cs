using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class average : MonoBehaviour {
    public static Color ColorAverage(List<Color> color)
    {
        Color while_color = new Color(0, 0, 0, 0);
        for (int a = 0; a < color.Count; a++)
        {
            while_color += color[a] / color.Count;
        }
        return while_color;
    }
}
