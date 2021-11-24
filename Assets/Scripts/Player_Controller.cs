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
    
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 2;
        xAngle = rotationSpeed;
        stopRotation = 0;
        speed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        // Set Player Rotation
        player.transform.Rotate(xAngle, yAngle, zAngle * Time.deltaTime, Space.Self );

        //Set Mouse Input
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //if Button is pressed stop rotation
            xAngle = stopRotation;
            //Player Movement when Button is pressed
            player.transform.Translate(new Vector3(0,speed,0) * Time.deltaTime, Space.Self); 
        }
        
        // Button unpressed, start rotation with xAngle
        if ( Input.GetKeyUp(KeyCode.Mouse0))
        {
            xAngle = rotationSpeed;
        }

      
    }
}
