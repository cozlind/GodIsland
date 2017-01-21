using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour, IHumanCreate {

    List<Human> _HumanList = new List<Human>();

    [SerializeField]
    GameObject humanPrefab;

    [SerializeField]
    float _maxAttack = 100;
    [SerializeField]
    float _maxHp = 10000;

    [SerializeField]
    float _minAttack = 1;
    [SerializeField]
    float _minHp = 1;

    public void Create(HumanStatus status1, HumanStatus status2, Vector3 position)
    {
        HumanStatus status = new HumanStatus();
        status.color = BornAlgorithm.GetBornColor( status1.color, status2.color );
        status.attack = Mathf.Lerp(_minAttack, _maxAttack,  HumanStatusAlgorithm.GetBornHpPersent(status.color));
        status.hp = Mathf.Lerp(_minHp, _maxHp, HumanStatusAlgorithm.GetAttackPersent(status.color));

        Human human = Instantiate( humanPrefab, position, Quaternion.identity, this.transform ).GetComponent<Human>();
        
        _HumanList.Add( human );
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
