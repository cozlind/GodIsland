using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttackCtrl : MonoBehaviour {
    public bool buttle = false;
    public float speed;
    public bool kamehameShot = false;
    public GameObject kamehameha;
    public GameObject aimEnemy;
    Animator humanAnim;

	// Use this for initialization
	void Start () {
        humanAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        AttackUpdate();
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
            Debug.Log("( ;∀;)");
            humanAnim.Play("Human_Kamehameha", 0);
        }
    }

    public void Kamehameha()
    {
        Instantiate(kamehameha, transform.position + new Vector3 (0,1.3f,0), transform.rotation);

    }
}
