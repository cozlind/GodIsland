using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossFeedUI : MonoBehaviour
{
    public GameObject parent_story;
    public GameObject parent_config;

    Graphic[] storys = new Graphic[3];
    Graphic[] configs = new Graphic[8];

    //public List<Text> story_1, story_2, story_3;
    //public Text config_1, config_2, config_3, config_4, config_5, config_6, config_7, config_8;

    float timer;
    public float fadeSecondTime = 3;

    float alpha;

    float configAlpha;

    bool isClick;

    // Use this for initialization
    void Start()
    {
        storys = parent_story.GetComponentsInChildren<Text>();
        configs = parent_config.GetComponentsInChildren<Text>();

        alpha = 1f;
        for (int i = 0; i < storys.Length; ++i)
        {
            Color color = storys[i].color;
            color.a = alpha;
            storys[i].color = color;
        }

        configAlpha = 0f;
        for (int i = 0; i < configs.Length; ++i)
        {
            Color color = configs[i].color;
            color.a = configAlpha;
            configs[i].color = color;
        }

        isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick == true)
            CrossFeed();
    }

    public void CrossFeed()
    {
        timer += Time.deltaTime;

        if (timer < fadeSecondTime)
        {
            alpha = Mathf.Lerp(1, 0, timer / fadeSecondTime);
            for (int i = 0; i < storys.Length; ++i)
            {
                Color color = storys[i].color;
                color.a = alpha;
                storys[i].color = color;
            }

            //configAlpha = alpha - 1f;
            configAlpha = Mathf.Lerp(0, 1, timer / fadeSecondTime);
            for (int i = 0; i < configs.Length; ++i)
            {
                Color color = configs[i].color;
                color.a = configAlpha;
                configs[i].color = color;
            }
        }

        //if (timer >= fadeSecondTime)
        //{
        //    //alpha = Mathf.Lerp(1, 0, (timer/2) / fadeSecondTime);
        //    //aplha値反転
        //    //float configAlpha = 1 - alpha;

        //}
    }

    public bool IsClick
    {
        get { return isClick; }
        set { isClick = value; }
    }
}
