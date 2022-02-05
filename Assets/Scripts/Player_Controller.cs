using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Controller : MonoBehaviour
{
    // set variables for rotation speed and movement speed
    public float rotationSpeed = 330f;
    public float speed = 60f;
    private float resetRotSpeed;
    private float resetSpeed;

    // position where the player should respawn and respawn counter
    public Transform spawnPoint; 
    public int respawnCounter = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        // store default values for player respawn
        resetRotSpeed = rotationSpeed;
        resetSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // if space is held, stop rotation and move forward
        if (Input.GetKey(KeyCode.Space)) {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self); 
        } else {
            // constant player rotation around X angle
            gameObject.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
    }
    
    // check for collisions of player
    private void OnCollisionEnter(Collision col)
    {
        // check if respawn is necessary (colliding object tagged with Respawn) 
        if (col.gameObject.CompareTag("Respawn"))
        {
            // play hit sound
            SoundManager.Instance.PlaySoundEffect(SoundManager.Instance.resetClip, 0.15f);

            // reset player values to default
            rotationSpeed = resetRotSpeed;
            speed = resetSpeed;
            gameObject.GetComponent<GetSpeedUp>().boosting = false;
            gameObject.GetComponent<GetSpeedUp>().wetTrail.SetActive(false);

            // Reset Player Position
            transform.position = spawnPoint.transform.position;
            transform.rotation = Quaternion.identity;

            // add to respawnCounter
            respawnCounter++;
        } 
        // check if player made it to the end
        else if (col.gameObject.CompareTag("Finish")) {
            // call winning function
            gameObject.GetComponent<GameOver>().DisplayGameOverUI(true);
        }
    }
}
