using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeedUp : MonoBehaviour
{

    // variable to check if player currently is sped up & trail-effect + sound gameobject
    public bool boosting = false;
    public GameObject wetTrail;

    // Start is called before the first frame update
    void Start()
    {

        // deactivate the trail effect at the beginning of the level
        wetTrail.SetActive(false);        
    }

    // speed-up when player collides with yellow Obstacles (tagged with SpeedUp), activate trail and not already boosted
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedUp" && !boosting)
        {
            boosting = true;
            wetTrail.SetActive(true);
            
            // play audio clip
            SoundManager.Instance.PlaySoundEffect(SoundManager.Instance.puddleClip, 0.1f);

            // modify speed values
            gameObject.GetComponent<Player_Controller>().rotationSpeed *= 1.5f;
            gameObject.GetComponent<Player_Controller>().speed *= 1.5f;
        }
    }
}
