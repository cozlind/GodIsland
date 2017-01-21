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

    //GiantHP hp;

    public float speed = 0.5f;
    public float sleepTime = 0;
    public float readyTime = 0;
    public GameObject searchHumanArea;
    public GameObject aimHuman;

    Animator blackAnim;
    // Use this for initialization
    void Start()
    {
        blackAnim = GetComponent<Animator>();
        searchHumanArea = GameObject.Find("SearchRangeSphere");
        //hp = GetComponent<GiantHP>();
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
        if (sleepTime >= 3)
        {
            blackAnim.SetBool("ready", true);
            bg_type = Type.Ready;
        }
        sleepTime+= Time.deltaTime;
    }

    private void ReadyUpdate()
    {
        if (readyTime >= 3)
        {
            blackAnim.SetBool("attack", true);
            bg_type = Type.Attack;
        }
        readyTime+= Time.deltaTime;
    }

    private void AttckUpdate()
    {
        aimHuman = searchHumanArea.GetComponent<SearchCharacter>().aimHuman;
        Vector3 relativePos = aimHuman.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = new Quaternion(transform.rotation.x, Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed).y, transform.rotation.z, Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed).w);

        if (aimHuman != null)
        {
            blackAnim.SetTrigger("attack");
        }
    }
}
