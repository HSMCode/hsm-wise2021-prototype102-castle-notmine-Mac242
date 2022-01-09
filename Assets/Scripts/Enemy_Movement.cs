using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private float walkingDistance = 1.9f;
    private float speed = 50f;
    // variables to check for moving direction
    private bool moveForward = true;
    private float positionChange = 0;

    // Update is called once per frame
    void Update()
    {
        // update variable to check if enemy has hit walking distance and shound change directions
        if (positionChange > walkingDistance) {
            moveForward = false;
        } else if (positionChange < -1 * walkingDistance) {
            moveForward = true;
        }


        // every enemy moves forwards and backwards along the local x-axis
        for (int i = 0; i < enemies.Length; i++)
        {

            // check for direction
            if (moveForward) {
                positionChange += Time.deltaTime;
                enemies[i].transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else {
                positionChange -= Time.deltaTime;
                enemies[i].transform.Translate(Vector3.back * Time.deltaTime * speed);
            }
        }
    }
}
