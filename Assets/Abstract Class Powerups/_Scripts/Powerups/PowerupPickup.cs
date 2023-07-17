using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClassPowerups
{

public class PowerupPickup : MonoBehaviour
{
    public Powerup powerup;
    public Powerups powerupDrop;

    void Start()
    {
        powerup = AssignItem(powerupDrop);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerupsManager player = collision.GetComponent<PowerupsManager>();

        if (player != null)
        {
            AddPowerup(player);
            Destroy(gameObject);
        }
    }

    public void AddPowerup(PowerupsManager player)
    {
        foreach(PowerupList p in player.powerups)
        {
            if (p.name == powerup.GiveName())
            {
                p.stack += 1;
                return; // Will prevent the code from running the code below
            }
        }
        player.powerups.Add(new PowerupList(powerup, powerup.GiveName(), 1));
    }


    public Powerup AssignItem(Powerups powerupToAssign)
    {
        switch(powerupToAssign)
        {
            case Powerups.HealthRegenPowerup:
                return new HealthRegenPowerup();
            default:
                return new HealthRegenPowerup();
        }
    }
}

public enum Powerups
{
    HealthRegenPowerup
}

}