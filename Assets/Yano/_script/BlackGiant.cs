using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackGiant : MonoBehaviour
{
    public enum Type
    {
        Sleep,
        Ready,
        Attack,
    }
    public Type bg_type = Type.Sleep;

    GiantHP hp;

    int sleepTime = 0;

    int readyTime = 0;

    // Use this for initialization
    void Start()
    {
        hp = GameObject.Find("BlackGiant").GetComponent<GiantHP>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (bg_type)
        {
            case Type.Sleep:
                SleepUpdate();
                break;

            case Type.Ready:
                ReadyUpdate();

                break;

            case Type.Attack:
                AttckUpdate();
                break;
        }
    }

    private void SleepUpdate()
    {
        if (sleepTime == 120)
            bg_type = Type.Ready;
        sleepTime++;
    }

    private void ReadyUpdate()
    {
        if (readyTime == 60)
            bg_type = Type.Attack;
        readyTime++;
    }

    private void AttckUpdate()
    {
    } 
}
