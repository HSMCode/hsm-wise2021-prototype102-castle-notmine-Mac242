using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy1;
    [SerializeField] private GameObject[] enemy2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemy1.Length; i++)
        {
            enemy1[i].transform.Translate(new Vector3(0,0.3f,-0.3f) * Mathf.Sin(Time.time + (float)i / enemy1.Length));
        }
        
        for (int i = 0; i < enemy2.Length; i++)
        {
            enemy2[i].transform.Translate(new Vector3(0,0,-0.3f) * Mathf.Sin(Time.time + (float)i / enemy2.Length));
        }
    }
}
