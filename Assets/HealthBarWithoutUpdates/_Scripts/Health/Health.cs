using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : Gauge, IDamageable, IHealable
{
    [SerializeField] private UnityEvent _onDie; // Event for when the unit dies

    // Add IDamageable function
    public void Damage(float damageAmount)
    {
        Current -= damageAmount;
        
        if(Current <= 0)
        {
            _onDie.Invoke();
            Debug.Log(gameObject.name + " has died!");
            Destroy(gameObject);
        }
        
    }
    // Add IHealable function
    public void Heal(float healAmount)
    {
        Current += healAmount;

        if (Current > Initial)
        {
            Current = Initial;
        }
    }
}
