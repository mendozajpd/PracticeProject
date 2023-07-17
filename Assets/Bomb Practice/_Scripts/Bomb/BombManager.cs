using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BombPractice
{

public class BombManager : MonoBehaviour
{
    public float DetonationTime = 1.5f;
    [SerializeField] IBombType _bombType;
    [SerializeField] IBombBehavior _bombBehavior;

    private void Awake()
    {
        _bombType = GetComponent<IBombType>();    
    }

    private IEnumerator Start()
    {
        if (_bombType != null)
        {
            if (DetonationTime > 0)
            {
                yield return new WaitForSeconds(DetonationTime);
                _bombType.Explode();
            }
        }
    }

    void Update()
    {

    }

    public void Boom()
    {
        _bombType.Explode();
    }

}

}