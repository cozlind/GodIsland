using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIwaku : MonoBehaviour {

    public RectTransform[] _RT;

    public void BUTTON0()
    {
        transform.position = _RT[0].position;
    }

    public void BUTTON1()
    {
        transform.position = _RT[1].position;
    }

    public void BUTTON2()
    {
        transform.position = _RT[2].position;
    }

    public void BUTTON3()
    {
        transform.position = _RT[3].position;
    }
}
