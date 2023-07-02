using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventButtonScript : MonoBehaviour
{
    public UnityEvent ButtonPressed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PressButton();
        }
        
    }

    public void PressButton()
    {
        ButtonPressed.Invoke();
    }
}
