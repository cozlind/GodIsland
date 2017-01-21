using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttack : MonoBehaviour {

    public GameObject Ball;
    private Transform God;
    public float Speed;

    // Use this for initialization
    void Start () {
        God = GameObject.Find("Giant").transform;
    }

    // Update is called once per frame
    void Update () {

        //ビームの判定の代わり
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (gameObject.CompareTag("WhiteMan"))
            {
                Instantiate(Ball, transform.position, Quaternion.identity);
            }
        }

        //自分が白以外の人だったら体当たりしにいく
        if (gameObject.CompareTag("human"))
        {
            transform.LookAt(new Vector3(God.position.x,transform.position.y, God.position.z));
            transform.position += transform.forward * Speed;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        //巨人に当たったら自分の位置を下げる
        if (c.name == "Giant")
        {
            transform.position -= transform.forward * Speed * 20;
        }
    }
}