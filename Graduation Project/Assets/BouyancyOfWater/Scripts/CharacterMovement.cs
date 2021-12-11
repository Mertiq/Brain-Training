using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BouyancyOfWater{

    [RequireComponent(typeof(CharacterController2D))]
    public class CharacterMovement : MonoBehaviour
{
    private CharacterController2D controller;

    //public GameObject gameOverPanel;
    public float speed = 4.0f;
    private bool isJump = false;
    private float horizontalMovement = 0.0f; 
    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
         horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
         if(Input.GetButtonDown("Jump"))
         {
             isJump = true;
         }
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
           
        }
        else if(col.transform.tag == "Water")
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        else if(col.transform.tag == "FinishPoint")
        {
            //gameOverPanel.SetActive(true);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.transform.tag == "Ground" ||col.transform.tag == "Wood")
        {
           
        }
    }
}
}