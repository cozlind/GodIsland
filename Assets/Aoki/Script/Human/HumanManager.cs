using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour, IHumanCreate
{


    public List<Human> _HumanList = new List<Human>();
    List<Material> _MaterialList = new List<Material>();
    int humanCreateCount = 0;
    [SerializeField]
    Material drawMaterial;
    [SerializeField]
    TerrainManager terrainManager;
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
        status.color = BornAlgorithm.GetBornColor(status1.color, status2.color);
        status.attack = Mathf.Lerp(_minAttack, _maxAttack, HumanStatusAlgorithm.GetBornHpPersent(status.color));
        status.hp = Mathf.Lerp(_minHp, _maxHp, HumanStatusAlgorithm.GetAttackPersent(status.color));

        Human human = Instantiate(humanPrefab, humanPrefab.transform.position, Quaternion.identity, this.transform).GetComponent<Human>();
        human.GetComponent<DynamicPathFinding>().unitScript.transform.position = position;
        human.GetComponent<DynamicPathFinding>().terrainScript = terrainManager;
        human.Init(status, FindNearColorMaterial(status.color));
        humanCreateCount++;
        _HumanList.Add(human);
    }

    public void Create(HumanStatus humanStatus, Vector3 position)
    {
        HumanStatus status = humanStatus;

        Human human = Instantiate(humanPrefab, humanPrefab.transform.position, Quaternion.identity, this.transform).GetComponent<Human>();
        human.Init(status, FindNearColorMaterial(status.color));
        human.GetComponent<DynamicPathFinding>().unitScript.transform.position = position;
        human.GetComponent<DynamicPathFinding>().terrainScript = terrainManager;
        humanCreateCount++;
        _HumanList.Add(human);
    }

    public Material FindNearColorMaterial(Color findColor)
    {
        Material nearMaterial = _MaterialList[0];
        float minDiff = 10;
        foreach (Material material in _MaterialList)
        {
            float diff = 0;
            int a = ResultData.Instance.createHuman;
            Color color = material.GetColor("_Color");
            diff = Math.Abs(color.r - findColor.r) + Math.Abs(color.g - findColor.g) + Math.Abs(color.b - findColor.b);
            if (diff < minDiff)
            {
                minDiff = diff;
                nearMaterial = material;
            }

        }
        return nearMaterial;
    }

    // Use this for initialization
    void Start()
    {
        int division = 3;

        for (int r = 0; r < division; ++r)
        {
            for (int g = 0; g < division; ++g)
            {
                for (int b = 0; b < division; ++b)
                {
                    Material material = new Material(drawMaterial);
                    Color color = new Color(r, g, b, 1) / 4.0f;
                    material.SetColor("_Color", color);
                    _MaterialList.Add(material);
                }
            }
        }
    }

    public int GetHumanAliveCount()
    {
        return _HumanList.Count;
    }

    public int GetHumanCreateCount()
    {
        return humanCreateCount;
    }
}
