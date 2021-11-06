using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    public GameObject gameOverPanel;
    public bool groundedPlayer;
    public float playerSpeed = 4.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -1.81f;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }

        // Changes the height position of the player..
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
       playerVelocity.y += gravityValue * Time.deltaTime;
       controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ground" || col.tag == "Wood")
        {
            groundedPlayer = true;
        }
        else if(col.tag == "Water")
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        else if(col.tag == "FinishPoint")
        {
            gameOverPanel.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Ground" ||col.tag == "Wood")
        {
            groundedPlayer = false;
        }
    }
}
