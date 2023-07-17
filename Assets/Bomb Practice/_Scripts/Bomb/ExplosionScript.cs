using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombPractice
{

public class ExplosionScript : MonoBehaviour
{

    private ParticleSystem _particles;
    private void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _destroyWhenInactive();
    }

    private void _destroyWhenInactive()
    {
        if (!_particles.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}

}