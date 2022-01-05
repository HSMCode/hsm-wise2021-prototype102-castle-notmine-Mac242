using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private float walkingDistance = 2f;
    private float speed = 60f;

    // Update is called once per frame
    void Update()
    {
        // every enemy moves forwards and backwards along the local x-axis
        for (int i = 0; i < enemies.Length; i++)
        {
            //enemies[i].transform.Translate(new Vector3(0,0.3f,-0.3f) * Mathf.Sin(Time.deltaTime + (float)i / enemies.Length));
            enemies[i].transform.Translate(Vector3.forward * Mathf.Sin(Time.time * walkingDistance) * Time.deltaTime * speed);
        }
    }
}
