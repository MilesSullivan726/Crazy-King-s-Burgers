using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    private AudioSource audioSource;
    private bool threatPresent = false;
    private bool flashLightOn = false;
    public AudioClip flashlightSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator HallwayFlash()
    {
        if (flashLightOn)
        {
            threatPresent = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            threatPresent = false;
        }
    }

    private void OnMouseDown()
    {
        flashLightOn = true;
        audioSource.PlayOneShot(flashlightSFX);
    }

    private void OnMouseDrag()
    {
        if (!threatPresent)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnMouseUp()
    {
        flashLightOn = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
