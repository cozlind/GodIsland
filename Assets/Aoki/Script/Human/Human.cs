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
    Color _currentColor = new Color();

    // Use this for initialization
    public void Init(HumanStatus status)
    {
        _status = status;
        _currentColor = _status.color;
        Material m = drawRenderer.material;
        m.SetColor("_Color", _status.color);
    }

    void Start()
    {
        Init(_status);
    }

    public HumanStatus GetStatus()
    {
        return _status;
    }

    public Color GetColor()
    {
        return _currentColor;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        _status.color = _currentColor;

        Material m = drawRenderer.material;
        m.SetColor("_Color", _status.color);
#endif
    }
}
