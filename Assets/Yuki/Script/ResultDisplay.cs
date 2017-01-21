using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    public Text surviveHumansText;
    public Text deadHumansText;
    public Text birthHumansText;

    ResultData result_date;

    // Use this for initialization
    void Start()
    {
        result_date = ResultData.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        surviveHumansText.text = "SurviveHumans:" + result_date.AliveHuman;
        deadHumansText.text = "DeadHumans:" + result_date.deadHuman;
        birthHumansText.text = "BirthHumans:" + result_date.createHuman;
    }
}
