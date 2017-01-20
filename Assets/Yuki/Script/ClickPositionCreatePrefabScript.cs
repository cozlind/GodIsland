using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionCreatePrefabScript : MonoBehaviour {
    private float shotWait = 0;
    public float speed = 3000.0f;
    [SerializeField]
    private GameObject Prefab;
    public Vector3 hitPoint;

    void Start()
    {

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

        // マウス入力で左クリックをした瞬間
        if (Input.GetMouseButtonDown(0))
        {
            shotWait = 0.3f;
            //マウスカーソルからRay放射
            // maincameraにtagを設定する
            // boxcolliderをつける
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 仮想的な線を利用した衝突検出する
            // カメラから、マウス入力のあった位置までの間にある、オブジェクトを格納する
            // 任意の位置から任意の方向に向けて架空の線を出し、その線分上にあるオブジェクトを取得する

            // RaycastHit型の変数
            RaycastHit hit;

            // if(Physics.Raycast( transform.position,Vector3.right,out hit, 10 ))
            // positionから右方向に10進んだ先までにオブジェクトがあればtrueが返される
            // 第三引数にoutで指定すると衝突したオブジェクトの情報が入る

            // 第一引数にはRaycastの原点の位置、第二引数は方向、
            // 第三引数には衝突情報、第四引数には検知を行う距離、第五引数にはレイヤーマスクをとります
            // ※第三引数まで必須

            // Rayが飛ばされたところから、1000の間にオブジェクトがあればtrueを返し、hitにそれを格納する
            if (Physics.Raycast(ray, out hit, 1000))
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
            Instantiate(Prefab, hitPoint, transform.rotation);
        }
    }
}
