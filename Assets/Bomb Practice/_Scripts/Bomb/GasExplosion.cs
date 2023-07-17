using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombPractice
{

public class GasExplosion : MonoBehaviour, IBombType
{
    [SerializeField] private GameObject _gasParticles;

    public void Explode()
    {
        Instantiate(_gasParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

}