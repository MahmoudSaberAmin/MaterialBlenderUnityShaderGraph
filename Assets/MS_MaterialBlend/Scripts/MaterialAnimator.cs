using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimator : MonoBehaviour
{
    public bool IsAnimating = true;
    public bool IsPingPong = true;
    [SerializeField] private Material _material;
    [SerializeField] private string _varialbleName;
    [SerializeField] private float _min;
    [SerializeField] private float _max;
    [SerializeField] private bool _isUp;

    private float _variable;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        _variable = _min;
        IsAnimating = true;
    }

    public void PingPong()
    {
        IsAnimating = true;
        IsPingPong = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAnimating==true)
        {
            if (IsPingPong)
            {
                _material.SetFloat(_varialbleName, (_isUp?1:-1)* (Mathf.PingPong(Time.time, _max-_min)+_min));
            }
            else
            {
                if (_variable<_max)
                {
                    _variable += Time.deltaTime;
                    _material.SetFloat(_varialbleName, (_isUp ? 1 : -1) * _variable);
                }
                else
                {
                    IsAnimating = false;
                }
            }
        }
    }
}
