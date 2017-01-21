using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{
    enum State
    {
        Move,
        Rotation,
        Tree_discover,
    }

    [SerializeField]
    private GameObject treeObj;

    public LayerMask ground;
    public LayerMask fieldObj;

    State humanState;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float rorateSpeed;

    int moveTime;
    int rotateTime;
    int stayTime;
    int randomTime;

    // Use this for initialization
    void Start()
    {
        Initialize();
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
                if (GameObject.FindGameObjectWithTag("tree") != null)
                {
                    transform.LookAt(treeObj.transform.position);
                    this.transform.position += treeObj.transform.position * 0.01f; ;
                }

                break;
        }

        TreeDiscover();
    }

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

    public void MoveUpdate()
    {
        if (moveTime >= randomTime)
        {
            rotateTime = 0;
            stayTime = (int)Random.Range(60f, 180f + 1);
            humanState = State.Rotation;
        }

        Ray ray_front = new Ray(transform.localPosition, transform.forward);
        Debug.DrawRay(ray_front.origin, ray_front.direction * 3, Color.red);
        RaycastHit hitInfo_front;

        if (Physics.Raycast(ray_front, out hitInfo_front, 2f, fieldObj))
        {
            rotateTime = 0;
            stayTime = (int)Random.Range(60f, 180f + 1);
            humanState = State.Rotation;
            return;
        }

        Ray ray_low = new Ray(transform.localPosition + transform.forward * 2f, -transform.up);
        Debug.DrawRay(ray_low.origin, ray_low.direction * 3, Color.red);
        RaycastHit hitInfo_low;
        if (Physics.Raycast(ray_low, out hitInfo_low, ground))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        moveTime++;
    }

    public void RotationUpdate()
    {
        rotateTime++;
        transform.Rotate(Vector3.up, rorateSpeed * Time.deltaTime);

        if (rotateTime >= stayTime)
        {
            moveTime = 0;
            randomTime = (int)Random.Range(60f, 180f + 1);
            humanState = State.Move;
        }
    }

    public void TreeDiscover()
    {
        if (GameObject.FindGameObjectWithTag("tree") != null)
        {
            treeObj = GameObject.FindGameObjectWithTag("tree").gameObject;
            humanState = State.Tree_discover;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "tree")
        {
            humanState = State.Rotation;
            Destroy(other.gameObject);
        }
    }
}
