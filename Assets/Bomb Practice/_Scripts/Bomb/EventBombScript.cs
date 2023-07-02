using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBombScript : MonoBehaviour
{
    public UnityEvent OnBoom;
    public float DetonationTime = 1.5f;
    [SerializeField] IBombType _bombType;
    [SerializeField] IBombBehavior _bombBehavior;

    private void Awake()
    {
        _bombType = GetComponent<IBombType>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }
    }

    private void Explode()
    {
        OnBoom.Invoke();
    }
}
