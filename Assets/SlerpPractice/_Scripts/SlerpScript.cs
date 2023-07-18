using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SlerpPractice
{

    public class SlerpScript : MonoBehaviour
    {


        [SerializeField] private Vector2 defaultPos;
        [SerializeField] private Vector2 targetPos;
        [SerializeField] private float moveAmount;

        [SerializeField] private Camera mainCamera;
        [SerializeField] private Vector3 mousePos;

        [SerializeField] private int shoot = 0;
        [SerializeField] private bool overhand;

        private void Start()
        {
            transform.position = defaultPos;
        }


        private void Update()
        {
            if(Input.GetButtonUp("Fire1"))
            {
                shoot = shoot == 0 ? 1 : 0;
                getTrajectory();
            }

            if (Input.GetButtonUp("Fire2"))
            {
                overhand = !overhand;
            }

            if (shoot == 1 && moveAmount < 1)
            {
                moveAmount += Time.deltaTime * 2;
                transform.position = MathParabola.Parabola(defaultPos, targetPos, getHeight(overhand), moveAmount);
            }

            if (moveAmount >= 1)
            {
                shoot = 0;
                moveAmount %= 1;
                transform.position = defaultPos;
            }


        }

        private void getTrajectory()
        {
            getMousePos();
            
            targetPos = new Vector2(mousePos.x, mousePos.y);
        }
        private void getMousePos()
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        private float getHeight(bool isOverhand)
        {

            float distance = Vector2.Distance(defaultPos, targetPos) / (isOverhand ? 4 : -4);

            return distance;
        }
    }

}