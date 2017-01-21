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
		
	}

    public void AddTree( Vector3 position, Quaternion quaternion )
    {
        treeList.Add(Instantiate( treePrefab, position, treePrefab.transform.rotation*quaternion, this.transform));
    }

}
