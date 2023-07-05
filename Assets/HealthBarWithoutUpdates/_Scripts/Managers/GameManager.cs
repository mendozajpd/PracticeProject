using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Health> thingsToGetDamaged = new List<Health>();

    void Update()
    {
        if (thingsToGetDamaged.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {

                for (var i = 0; i < thingsToGetDamaged.Count; i++ )
                {
                    if (thingsToGetDamaged[i] == null)
                    {
                        thingsToGetDamaged.RemoveAt(i);
                        break;
                    }

                    thingsToGetDamaged[i].Damage(25);
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                for (var i = 0; i < thingsToGetDamaged.Count; i++)
                {
                    thingsToGetDamaged[i].Heal(25);
                }
            }
        }
    }

    public void AnnounceDeath()
    {
        Debug.Log("I DIED");
    }
}
