using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIanm : MonoBehaviour
{
    public Image title_start;
    Graphic g;

    float alpha = 1f;

    float time;

    [SerializeField]
    private float blinkTime;
    [SerializeField]
    private float idensity;

    bool isMass = false;

    // Use this for initialization
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "startscene":
                g = title_start.GetComponent<Graphic>();
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        switch (SceneManager.GetActiveScene().name)
        {
            case "startscene":
                textBlink();
                Color color = g.color;
                color.a = alpha;
                g.color = color;

                break;

            default:
                break;
        }
    }

    private float textBlink()
    {
        if (isMass == false)
        {
            alpha = Mathf.Lerp(1, idensity, time / blinkTime);
            if (alpha <= idensity)
            {
                isMass = true;
                time = 0;
            }
        }
        else if (isMass == true)
        {
            alpha = Mathf.Lerp(idensity, 1, time / blinkTime);
            if (alpha >= 1f)
            {
                isMass = false;
                time = 0;
            }
        }

        return alpha;
    }
}