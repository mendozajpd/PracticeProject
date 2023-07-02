using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Camera _mainCamera;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(_bombPrefab, mousePosition, Quaternion.identity);
        }
    }
}
