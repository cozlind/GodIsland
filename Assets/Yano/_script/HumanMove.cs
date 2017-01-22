using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{
    public enum State
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

    public State humanState;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rorateSpeed;

    private int moveTime;
    private int rotateTime;
    private int stayTime;
    private int randomTime;

    public float speed = 3;
    public bool kamehameShot = false;
    public GameObject kamehameha;

    public GameObject aimEnemy;
    Animator humanAnim;

    // Use this for initialization
    void Start()
    {
        Initialize();
        // blackGiant = GameObject.Find("Black").GetComponent<BlackGiant>();
        blackGiant = GameObject.FindObjectOfType<BlackGiant>();
        humanAnim = GetComponent<Animator>();
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
                AttackUpdate();
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
        randomTime = (int)Random.Range(60f, 360f + 1);
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

        Ray ray_front = new Ray(transform.localPosition+new Vector3(0f,0.5f,0f), transform.forward);
        //Debug.DrawRay(ray_front.origin, ray_front.direction, Color.red);
        RaycastHit hitInfo_front;

        if (Physics.Raycast(ray_front, out hitInfo_front, 1f, fieldObj))
        {
            rotateTime = 0;
            stayTime = (int)Random.Range(60f, 180f + 1);
            humanState = State.Rotation;
            return;
        }

        Ray ray_low = new Ray(transform.localPosition+new Vector3(0f,0.5f,0f) + transform.forward, -transform.up);
        //Debug.DrawRay(ray_low.origin, ray_low.direction, Color.red);
        RaycastHit hitInfo_low;
        //if (Physics.Raycast(ray_low, out hitInfo_low, 1f,ground))
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
            moveSpeed = 2;
            moveTime = 0;
            randomTime = (int)Random.Range(60f, 360f + 1);
            humanState = State.Move;
        }
    }

    public void AttackUpdate()
    {
        if (aimEnemy != null)
        {
            Vector3 relativePos = aimEnemy.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = new Quaternion(transform.rotation.x, Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed).y, transform.rotation.z, Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed).w);
        }

        if (kamehameShot == true)
        {
            humanAnim.Play("Human_Kamehameha", 0);

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

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Black")
        {
            humanState = State.Attack;
            aimEnemy = col.gameObject;
        }
    }

    public void Kamehameha()
    {
        Instantiate(kamehameha, transform.position + new Vector3(-0.313f, 0.646f, 0.314f), transform.rotation);
        
    }
}
