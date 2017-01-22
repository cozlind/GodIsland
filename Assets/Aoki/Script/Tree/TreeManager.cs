using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {


    List<GameObject> treeList = new List<GameObject>();
    [SerializeField]
    GameObject treePrefab;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        foreach ( GameObject obj in treeList )
        {
            AppleTree tree = obj.GetComponent<AppleTree>();
            if(tree.isDead)
            {
                Destroy( tree.gameObject );
            }
            if (tree.GetComponent<AppleTree>().isDead)
            {
                Destroy(tree.gameObject);
            }
        }

        treeList.RemoveAll((tree) => tree.GetComponent<AppleTree>().isDead == true);

    }

    public void AddTree( Vector3 position, Quaternion quaternion )
    {
        treeList.Add(Instantiate( treePrefab, position, treePrefab.transform.rotation*quaternion, this.transform));
    }

    public GameObject GetTree()
    {
        if(treeList.Count == 0)
        {
            return null;
        }
        int random = Random.Range( 0, treeList.Count);
        return treeList[random];
    }

    //public bool IsTreeDead()
    //{

    //}

}
