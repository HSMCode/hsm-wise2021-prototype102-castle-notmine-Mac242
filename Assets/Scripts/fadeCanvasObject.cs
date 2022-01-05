using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeCanvasObject : MonoBehaviour
{
    public float duration = .5f;
    // Start is called before the first frame update
    void Start()
    {
        var canv = gameObject.GetComponent<CanvasGroup>();
        // fades the object out
        StartCoroutine(Fade(canv));
    }
 
    IEnumerator Fade(CanvasGroup canvasgrp) {
        yield return new WaitForSeconds(1);
        float counter = 0;
        while (counter < duration) {
            counter += Time.deltaTime;
            canvasgrp.alpha = Mathf.Lerp(1, 0, counter / duration);
            yield return null;
        }
    }
}
