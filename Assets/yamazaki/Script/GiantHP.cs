using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHP : MonoBehaviour {

    public int HP, Beam, BodyBlow;

    void OnTriggerEnter(Collider c)
    {
        if (c.name == "Ball(Clone)")
        {
            //ビームのダメージ
            if (HP > 0) HP -= Beam;
            else if (HP <= 0) GodDeath();
            Destroy(c.gameObject);
        }
        if (c.CompareTag("human"))
        {
            //体当たりのダメージ
            if (HP > 0) HP -= BodyBlow;
            else if (HP <= 0) GodDeath();
        }
    }

    private void GodDeath()
    {
        Debug.Log("巨人は死んだ");
    }
}
