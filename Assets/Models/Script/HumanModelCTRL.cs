using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanModelCTRL : MonoBehaviour {
    //ポップする人間にバリエーションを与えようとしているスクリプト
    public SkinnedMeshRenderer skinMesh;
    public Animator humanAnim;

	void Start () {
        
	}
	
	void Sample () {
        //Humanに対する命令サンプル・このメソッドは実行してはいけない
        //キャラの色を変える
        skinMesh.materials[0].color = Color.red;
        //モーションを変える0～1でidle,walk,runに変化
        humanAnim.SetFloat("speed", 1.0f);
        //死亡モーションにする
        humanAnim.Play("Human_dead");
	}
    public void SetSpeed( float speed )
    {
        humanAnim.SetFloat("speed", speed);
    }
}
