﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LoveWaveShot : MonoBehaviour {
    private float shotWait = 0;
    [SerializeField]
    private GameObject LoveField;

    [SerializeField]
    private GameObject LoveWave;
    [HideInInspector]
    public Vector3 hitPoint;
    private GameObject player;
    private Vector3 shotPos;

    public LoveType type;

    [SerializeField]
    TerrainManager tManager;
    [SerializeField]
    GameObject treeShot;
    //[SerializeField]
    // public IHumanCreate humanCreate { get; set; }

    public AudioClip _Create, _Broke;
    private AudioSource _AS;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        _AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shotWait > 0)
        {
            shotWait -= Time.deltaTime;
            // returnでこのフレームを一旦抜ける
            return;
        }

        MouseClicks();
    }

    void MouseClicks()
    {

        if( EventSystem.current.currentSelectedGameObject != null )
        {
            return;
        }
        // マウス入力で左クリックをした瞬間
        if (Input.GetMouseButtonDown(0))
        {
            shotWait = 0.3f;
            //マウスカーソルからRay放射
            // maincameraにtagを設定する
            // boxcolliderをつける

            //Love波を放つ位置を決める為、メインカメラの位置を取得
            shotPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

            // 仮想的な線を利用した衝突検出する
            // カメラから、マウス入力のあった位置までの間にある、オブジェクトを格納する
            // 任意の位置から任意の方向に向けて架空の線を出し、その線分上にあるオブジェクトを取得する

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // RaycastHit型の変数
            RaycastHit hit;

            // if(Physics.Raycast( transform.position,Vector3.right,out hit, 10 ))
            // positionから右方向に10進んだ先までにオブジェクトがあればtrueが返される
            // 第三引数にoutで指定すると衝突したオブジェクトの情報が入る

            // 第一引数にはRaycastの原点の位置、第二引数は方向、
            // 第三引数には衝突情報、第四引数には検知を行う距離、第五引数にはレイヤーマスクをとります
            // ※第三引数まで必須

            // Rayが飛ばされたところから、10000の間にオブジェクトがあればtrueを返し、hitにそれを格納する
            if (Physics.Raycast(ray, out hit, 10000,1<<LayerMask.NameToLayer("Ground")))
            {
                if (hit.collider.gameObject == null)
                {
                    return;
                }
                // hitした位置を格納する
                hitPoint = hit.point;
            }
            else
            {
                return;
            }
            if(  UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
            {
                return;
            }
            if( type == LoveType.Love|| type == LoveType.Glow)
            {
                if( type == LoveType.Glow )
                {
                    LoveWave = treeShot;
                }
                 GameObject LoveShot = Instantiate(LoveWave, shotPos, transform.rotation);
                 LoveWaveMove love = LoveShot.GetComponent<LoveWaveMove>();
                if( love != null )
                {
                    love.type = type;
                }
            }
            else if( type == LoveType.Create )
            {
                tManager.HeightUp();
                _AS.clip = _Create;
                _AS.Play();

            }
            else
            {
                tManager.HeightDown();
                _AS.clip = _Broke;
                _AS.Play();
            }
            
            
            
            //LoveFieldManager love = LoveShot.GetComponent<LoveFieldManager>();
            //love.HumanCreate = humanCreate ;
        }
    }
}
