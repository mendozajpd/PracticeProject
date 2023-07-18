using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SlerpPractice
{

    public class SlerpScript : MonoBehaviour
    {


        [SerializeField] private Vector3 defaultPos;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] private float moveAmount;

        [SerializeField] private Camera mainCamera;
        [SerializeField] private Vector3 mousePos;

        [SerializeField] private float distanceCutoff;
        [SerializeField] private float percentageOfTheDistance;
        [SerializeField] private float trajectoryvalueX = 0.5f;
        [SerializeField] private float distanceBetweenTarget;
        [SerializeField] private int move;
        [SerializeField] private float speed;

        private void Awake()
        {
            mainCamera = Camera.main.GetComponent<Camera>();
        }
        void Start()
        {
        }

        void Update()
        {
            if (Input.GetButtonUp("Fire1"))
            {
                speed = 0;
                move = 0;
                moveAmount = 0;
                transform.position = defaultPos;

                transform.position = defaultPos;
                move = move == 1 ? 0 : 1;
                getTrajectory();
                speed = getSpeed();
            }
            if (move != 0 && moveAmount < 1)
            {
                moveAmount += Time.deltaTime + (speed * 0.001f);
                transform.position = Vector3.Slerp(defaultPos, targetPos, moveAmount);

            }

            if (Input.GetButtonUp("Fire2"))
            {

            }


            //if (moveAmount > 1)
            //{

            //}


        }


        private void getTrajectory()
        {
            getMousePos();
            getSpeed();
            targetPos = new Vector3(mousePos.x, mousePos.y, trajectoryvalueX);
        }

        private void getMousePos ()
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        }

        private float getSpeed()
        {
            distanceBetweenTarget = Vector2.Distance(defaultPos, targetPos);
            float multiplier = Mathf.Lerp(distanceCutoff, 0f, distanceBetweenTarget/percentageOfTheDistance);

            return multiplier;
        }
    }

}