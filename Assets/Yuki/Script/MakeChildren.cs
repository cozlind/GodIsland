using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChildren : MonoBehaviour {
    public bool rut = false;
    public GameObject nearHuman;
    public float searchTime = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rut == true) ChildrenMaking();
	}

    void ChildrenMaking()
    {
        searchTime += Time.deltaTime;
        if (searchTime >= 1.0f)
        {
            nearHuman = searchTag(gameObject, "Human");
            searchTime = 0;
        }

        transform.LookAt(nearHuman.transform);
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "LoveField") rut = true;
    }

    GameObject searchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}
