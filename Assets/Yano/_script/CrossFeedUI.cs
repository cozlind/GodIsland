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

    // Use this for initialization
    void Start()
    {
        storys = parent_story.GetComponentsInChildren<Text>();
        configs = parent_config.GetComponentsInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CrossFeed();
    }

    public void CrossFeed()
    {
        if (timer < fadeSecondTime)
        {
            timer += Time.deltaTime;
            // alphaは0.0～1.0
            float alpha = Mathf.Lerp(0, 1, timer / fadeSecondTime);

            for (int i = 0; i < storys.Length; ++i)
            {
                Color color = storys[i].color;
                color.a = alpha;
                storys[i].color = color;
            }

            //aplha値反転
            float configAlpha = 1 - alpha;
            for (int i = 0; i < configs.Length; ++i)
            {
                Color color = configs[i].color;
                color.a = configAlpha;
                configs[i].color = color;
            }
        }
    }

    public bool IsClick { get; set; }
}
