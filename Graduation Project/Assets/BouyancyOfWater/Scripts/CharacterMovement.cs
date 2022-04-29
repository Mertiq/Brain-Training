using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BouyancyOfWater{

    [RequireComponent(typeof(CharacterController2D))]
    public class CharacterMovement : MonoBehaviour
    {
        private CharacterController2D controller;

        public GameObject endGamePanel;
        public float speed = 4.0f;
        private bool isJump = false;
        private float horizontalMovement = 0.0f; 
        void Awake()
        {
            controller = GetComponent<CharacterController2D>();
        }

        private void Start()
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }

        void Update()
        {
            // horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
            // if(Input.GetButtonDown("Jump"))
            // {
            //     isJump = true;
            // }
        }
        public void Move(int direction) {
            horizontalMovement = direction * speed;
        }
        public void Jump() {
            isJump = true;
        }
        void FixedUpdate()
        {
            controller.Move(horizontalMovement * Time.fixedDeltaTime,false, isJump);
            isJump = false;
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.transform.tag == "Wood")
            {
                //
            }
            else if(col.transform.tag == "Water")
            {
                Destroy(gameObject);
                Debug.Log("Game Over");
            }
            else if(col.transform.tag == "FinishPoint")
            {
                Time.timeScale = 0;
                endGamePanel.SetActive(true);
            }
        }
        
    }
}