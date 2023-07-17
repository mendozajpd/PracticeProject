using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClassPowerups
{

[System.Serializable]
public abstract class Powerup 
{
    public abstract string GiveName();
    public virtual void Update(PowerupsManager player, int stack)
    {
    }

    public virtual void OnPickUp(PowerupsManager player, int stack)
    {
    }

}

public class HealthRegenPowerup : Powerup
{
    public override string GiveName()
    {
        return "Health Regen Powerup";
    }


    public override void Update(PowerupsManager player, int stack)
    {
        if (player.health.Current < player.health.Initial)
        {
            player.health.Current += 1 * stack;
        }

        if (player.health.Current > player.health.Initial)
        {
            player.health.Current = player.health.Initial;
        }
    }
}

}