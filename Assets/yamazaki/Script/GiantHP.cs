using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHP : MonoBehaviour {

    public int HP, Beam, BodyBlow;
    private float deathAnimTime;
    bool death = false;
    Animator blackAnim;
    AudioSource deadSE;
    SceneLoadManager loadResult;
    void Start () {
        deadSE = GetComponent<AudioSource>();
        loadResult = GetComponent<SceneLoadManager>();
        deathAnimTime = 5;
        blackAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (death == true)
        {
            deathAnimTime -= Time.deltaTime;

            if (deathAnimTime <= 0)
            {
                loadResult.enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.name == "Ball(Clone)")
        {
            //ビームのダメージ
            if (HP > 0) HP -= Beam;
            if (HP <= 0) GodDeath();
            Destroy(c.gameObject);
        }
        if (c.CompareTag("human"))
        {
            //体当たりのダメージ
            if (HP > 0) HP -= BodyBlow;
            if (HP <= 0) GodDeath();
        }
    }

    void GodDeath()
    {
        blackAnim.SetBool("dead", true);
        deadSE.Play();
        death = true;
    }
}
