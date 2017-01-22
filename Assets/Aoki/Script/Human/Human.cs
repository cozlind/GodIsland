using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Human : MonoBehaviour {

    [SerializeField]
    HumanStatus _status = new HumanStatus();

    [SerializeField]
    Renderer drawRenderer;

    [SerializeField]
    Unit unit;

    GameObject tree;

    //[SerializeField]
    //Color _currentColor = new Color();

    // Use this for initialization
    public void Init(HumanStatus status, Material material)
    {
        _status = status;
        //_currentColor = _status.color;
        Material m = drawRenderer.material;
        drawRenderer.material = material;
        //m.SetColor("_Color", _status.color);
    }

    public bool IsTree()
    {
        return tree !=null;
    }

    public void SetTree(GameObject tree)
    {
        this.tree = tree;
    }

    public HumanStatus GetStatus()
    {
        return _status;
    }

    public Color GetColor()
    {
        return _status.color;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        unit.target.position = targetPosition;
    }

 
}
