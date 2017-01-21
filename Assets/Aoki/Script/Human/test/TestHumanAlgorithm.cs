using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHumanAlgorithm : MonoBehaviour {

    [SerializeField]
    List<TestHuman> _testHumans = new List<TestHuman>();

    public GameObject humanObject;

	// Use this for initialization
	void Start () {

        float value = 15.0f / 255.0f;

        addTestHuman(new HumanStatus(new Color(value, 0, 0)));
        addTestHuman(new HumanStatus(new Color(0, value, 0)));
        addTestHuman(new HumanStatus(new Color(0, 0, value)));


    }

    // Update is called once per frame
    void Update () {
        if( Input.GetMouseButtonDown(0) )
        {
            int firstHumanIndex = Random.Range( 0, _testHumans.Count );
            int secondHumanIndex = Random.Range(0, _testHumans.Count);
            while( firstHumanIndex == secondHumanIndex )
            {
                secondHumanIndex = Random.Range(0, _testHumans.Count);
            }
            addTestHuman( BornAlgorithm.GetBornAddStatus( _testHumans[firstHumanIndex].GetStatus(), _testHumans[secondHumanIndex].GetStatus() ) );
        }
		
	}

    public void addTestHuman( HumanStatus status )
    {
        float x = Random.Range(-10.0f, 10.0f);
        float z = Random.Range(-10.0f, 10.0f);
        Vector3 humanPosition = new Vector3( x, 0.0f, z);
        TestHuman human = GameObject.Instantiate(humanObject, humanPosition, Quaternion.identity).AddComponent<TestHuman>();
        human.init( status );

        


        _testHumans.Add( human );
    }
    
}
