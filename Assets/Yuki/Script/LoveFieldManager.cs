using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveFieldManager : MonoBehaviour {
    public float countTime;
    private float time;
    private int humanCount;
    private int makeChildCount;
    public float scale;
    public GameObject human;
    private bool countFinished = false;
    private bool makingChild = false;
    //private IHumanCreate humanCreate;
    [SerializeField]
    List<GameObject> _ParentObjectList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        time = countTime;
        transform.localScale = new Vector3(scale, scale, scale);
        
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (countFinished == true && makingChild == false)
        {
            MakeChildren();
            makingChild = true;
        }

        if (time <= 0) Destroy(gameObject);
	}

    void MakeChildren()
    {
        for (int i = 0; i < makeChildCount; i++)
        {
            if(_ParentObjectList.Count < i*2)
            {
                break;
            }
            float randomPosX = Random.Range(-scale / 2, scale / 2);
            float randomPosZ = Random.Range(-scale / 2, scale / 2);
            Vector3 position = new Vector3(transform.position.x + randomPosX, transform.position.y + 3, transform.position.z + randomPosZ);
            // Instantiate(human, new Vector3(transform.position.x + randomPos, transform.position.y + 3, transform.position.z + randomPos), transform.rotation);
            HumanStatus status1 = _ParentObjectList[i * 2].GetComponent<Human>().GetStatus();
            HumanStatus status2 = _ParentObjectList[i * 2 + 1].GetComponent<Human>().GetStatus();
            IHumanCreate humanCreate = GameObject.Find("HumanManager").GetComponent<HumanManager>();
            humanCreate.Create(status1, status2,position );

        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (countFinished == false)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("human");
            foreach (GameObject obj in targets)
            {
                float dist = Vector3.Distance(obj.transform.position, transform.position);
                if (dist <= scale / 2)
                {
                    humanCount++;
                    _ParentObjectList.Add( obj );
                }
            }

            makeChildCount = (int)Mathf.Floor(humanCount / 2);
            countFinished = true;
        }
    }
}
