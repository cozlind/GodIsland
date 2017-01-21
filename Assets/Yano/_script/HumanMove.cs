﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{
    enum State
    {
        Move,
        Rotation,
        Tree_discover,
        Attack,
    }

    [SerializeField]
    private GameObject treeObj;

    private BlackGiant blackGiant;

    public LayerMask ground;
    public LayerMask fieldObj;

    State humanState;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rorateSpeed;

    private int moveTime;
    private int rotateTime;
    private int stayTime;
    private int randomTime;

    // Use this for initialization
    void Start()
    {
        Initialize();
        // blackGiant = GameObject.Find("Black").GetComponent<BlackGiant>();
        blackGiant = GameObject.FindObjectOfType<BlackGiant>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (humanState)
        {
            case State.Move:
                MoveUpdate();

                break;

            case State.Rotation:
                RotationUpdate();

                break;

            case State.Tree_discover:
                TreeDiscoverUpdate();

                break;

            case State.Attack:
                //黒巨人がいた際の処理
                //現在は止まる
                break;
        }
        ObjTagFind();
    }

    //人(Human)の動きの初期化
    public void Initialize()
    {
        if ((int)Random.Range(1f, 2f + 1) == 1)
            humanState = State.Move;
        else
            humanState = State.Rotation;

        moveTime = 0;
        rotateTime = 0;
        stayTime = (int)Random.Range(60f, 120f);
        randomTime = (int)Random.Range(60f, 180f + 1);
    }

    //移動(直進)時の更新処理
    public void MoveUpdate()
    {
        if (moveTime >= randomTime)
        {
            rotateTime = 0;
            stayTime = (int)Random.Range(60f, 180f + 1);
            humanState = State.Rotation;
        }

        Ray ray_front = new Ray(transform.localPosition, transform.forward);
        //Debug.DrawRay(ray_front.origin, ray_front.direction * 3, Color.red);
        RaycastHit hitInfo_front;

        if (Physics.Raycast(ray_front, out hitInfo_front, 2f, fieldObj))
        {
            rotateTime = 0;
            stayTime = (int)Random.Range(60f, 180f + 1);
            humanState = State.Rotation;
            return;
        }

        Ray ray_low = new Ray(transform.localPosition + transform.forward * 2f, -transform.up);
        //Debug.DrawRay(ray_low.origin, ray_low.direction * 3, Color.red);
        RaycastHit hitInfo_low;
        if (Physics.Raycast(ray_low, out hitInfo_low, ground))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        moveTime++;
    }

    //方向転換(回転)時の更新処理
    public void RotationUpdate()
    {
        rotateTime++;

        transform.Rotate(Vector3.up, rorateSpeed * Time.deltaTime);

        if (rotateTime >= stayTime)
        {
            moveSpeed = 2f;
            moveTime = 0;
            randomTime = (int)Random.Range(60f, 180f + 1);
            humanState = State.Move;
        }
    }

    //木が生成された時の更新処理
    public void TreeDiscoverUpdate()
    {
        if (GameObject.FindGameObjectWithTag("tree") != null)
        {
            transform.LookAt(treeObj.transform.position);
            transform.Translate(Vector3.forward * (moveSpeed + 2f) * Time.deltaTime);
        }
    }

    //オブジェクトをタグ検索
    public void ObjTagFind()
    {
        if (blackGiant.bg_type==BlackGiant.Type.Attack)
        {
            humanState = State.Attack;
            return;
        }

        else if (GameObject.FindGameObjectWithTag("tree") != null)
        {
            treeObj = GameObject.FindGameObjectWithTag("tree").gameObject;
            humanState = State.Tree_discover;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "tree")
        {
            rotateTime = 0;
            stayTime = (int)Random.Range(60f, 180f + 1);
            humanState = State.Rotation;
            Destroy(other.gameObject);
        }
    }
}
