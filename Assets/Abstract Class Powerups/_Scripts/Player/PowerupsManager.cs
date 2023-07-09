using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PowerupsManager : MonoBehaviour
{
    // Update Method Speed
    [SerializeField] private float updateSpeed = 1;
    // Player Variables
    public Health health;

    // Variables for powerups


    // Powerup Related Code
    public List<PowerupList> powerups = new List<PowerupList>();

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    void Start()
    {
        StartCoroutine(CallItemUpdate());
    }


    IEnumerator CallItemUpdate()
    {
        foreach (PowerupList p in powerups)
        {
            p.powerups.Update(this, p.stack);
        }
        yield return new WaitForSeconds(updateSpeed);
        StartCoroutine(CallItemUpdate());
    }
}
