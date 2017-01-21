using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazePointMove : MonoBehaviour {
    public float speed = 8.0f;
    //private Vector3 screenPoint;
    //private Vector3 offset;
    GameObject camera;
    Vector3 direction;
    public float angle;
    float beforeX;
    float beforeY;
    float afterX;
    float afterY;

    // Use this for initialization
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        RightMouseClickMove();
    }

    void RightMouseClickMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //カメラから見たオブジェクトの現在位置を画面位置座標に変換
            //screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            //取得したscreenPointの値を変数に格納
            beforeX = Input.mousePosition.x;
            beforeY = Input.mousePosition.y;

            //オブジェクトの座標からマウス位置(つまりクリックした位置)を引いている。
            //これでオブジェクトの位置とマウスクリックの位置の差が取得できる。
            //ドラッグで移動したときのずれを補正するための計算だと考えれば分かりやすい
            //offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(x, y, screenPoint.z));
        }

        if (Input.GetMouseButton(1))
        {
            //ドラッグ時のマウス位置を変数に格納
            afterX = Input.mousePosition.x;
            afterY = Input.mousePosition.y;

            if (beforeX < afterX)
            {
                transform.position += camera.transform.right * speed * Time.deltaTime;
            }
            else if (beforeX > afterX)
            {
                transform.position += camera.transform.right * -speed * Time.deltaTime;
            }

            if (beforeY < afterY)
            {

                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else if (beforeY > afterY)
            {
                transform.position += transform.forward * -speed * Time.deltaTime;
            }
        }
    }
}
