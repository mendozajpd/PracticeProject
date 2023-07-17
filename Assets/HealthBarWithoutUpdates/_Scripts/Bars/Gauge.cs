using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Gauge : MonoBehaviour
{
    [SerializeField] private float initialValue;
    [SerializeField] private float _current;

    public float Current 
    { 
        get
        {
            return _current;
        }
        set
        {
            _current = value;
            OnChange?.Invoke();
        }
    }

    public float Initial => initialValue;
    public float Ratio => _current / initialValue;
    public Action OnChange;
    public void Awake() => _current = initialValue;
}

