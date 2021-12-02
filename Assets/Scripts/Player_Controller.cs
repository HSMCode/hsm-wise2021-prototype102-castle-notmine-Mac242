using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class Player_Controller : MonoBehaviour
{
    public GameObject player;
    public float xAngle;
    public float yAngle;
    public float zAngle;
    public float speed;
    public float rotationSpeed;
    public float stopRotation;
    public Transform spawnPoint; // Position where the player should respawn

    //Speed Up 
    private bool boosting;
    
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 3;
        xAngle = rotationSpeed;
        stopRotation = 0;
        speed = 5;
        boosting = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Set Player Rotation
        player.transform.Rotate(xAngle, yAngle, zAngle * Time.deltaTime * rotationSpeed, Space.Self );

        //Set Mouse Input
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //if Button is pressed stop rotation
            xAngle = stopRotation;
            //Player Movement when Button is pressed
            player.transform.Translate(new Vector3(0,speed,0) * Time.deltaTime * speed, Space.Self); 
        }
        
        // Button unpressed, start rotation with xAngle
        if ( Input.GetKeyUp(KeyCode.Mouse0))
        {
            xAngle = rotationSpeed;
        }


    }

    //Speed Up when Player collides with yellow Obstacles (Tagged with SpeedUp)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedUp")
        {
            Debug.Log("Speed Up");
            boosting = true;
            rotationSpeed = 5;
            speed = 8;
        }
    }


    
    //Deactivate Speed Up when Respawn
    private void OnCollisionEnter(Collision col) // check for Collision
    {
        if (col.gameObject.CompareTag("Respawn"))  // Check if Player collides with Obstacles (Tagged with Respawn)
        {
            rotationSpeed = 3;
            speed = 5;
            xAngle = rotationSpeed;
            boosting = false;
        }

    }

 




}
