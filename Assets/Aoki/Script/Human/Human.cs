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

    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {

    }
}
