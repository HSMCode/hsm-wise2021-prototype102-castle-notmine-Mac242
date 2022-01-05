using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Controller : MonoBehaviour
{
    // set variables for rotation speed and movement speed
    public float rotationSpeed = 240f;
    public float speed = 45f;
    private float resetRotSpeed;
    private float resetSpeed;

    // position where the player should respawn and respawn counter
    public Transform spawnPoint; 
    public int respawnCounter = 0;

    // variable to check if player currently is sped up 
    private bool boosting = false;

    // save collected coins to bag and assign UI variable
    public int collectedCoins = 0;
    public TMP_Text textCoins;
    

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

    // speed-up when player collides with yellow Obstacles (tagged with SpeedUp) and not already boosted
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedUp" && !boosting)
        {
            boosting = true;
            rotationSpeed *= 2f;
            speed *= 2f;
        }
    }
    
    // check for collisions of player
    private void OnCollisionEnter(Collision col)
    {
        // check if respawn is necessary (colliding object tagged with Respawn) 
        if (col.gameObject.CompareTag("Respawn"))
        {
            // reset player values to default
            rotationSpeed = resetRotSpeed;
            speed = resetSpeed;
            boosting = false;

            // Reset Player Position
            transform.position = spawnPoint.transform.position;
            transform.rotation = Quaternion.identity;

            // add to respawnCounter
            respawnCounter++;
        } 
        // check if player collected a coin along the way
        else if (col.gameObject.CompareTag("Coin")) {
            collectedCoins++;

            // add collected coins to UI
            textCoins.text = "Coins:" + collectedCoins.ToString();

            // set collected coin inactive and destroy after short delay
            col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0.5f);
        }
        // check if player made it to the end
        else if (col.gameObject.CompareTag("Finish")) {
            // call winning function
            gameObject.GetComponent<GameOver>().DisplayGameOverUI(true);
        }
    }
}
