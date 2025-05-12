using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    private AudioSource audioSource;
    private bool threatPresent = false;
    private bool flashLightOn = false;
    private bool kingHasBeenFlashed = false;
    private bool queenHasBeenFlashed = false;
    public AudioClip flashlightSFX;
    public AudioClip atWindowScare;
    public Sprite darkness;
    public Sprite light;
    public GameObject kingPos;
    public GameObject queenPos;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!kingPos.activeSelf)
        {
            kingHasBeenFlashed = false;
        }
        if (!queenPos.activeSelf)
        {
            queenHasBeenFlashed = false;
        }
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
        //audioSource.volume = 0.2f;
        audioSource.PlayOneShot(flashlightSFX);
        if (kingPos.activeSelf && !kingHasBeenFlashed)
        {
            kingHasBeenFlashed = true;
            audioSource.volume = 1f;
            audioSource.PlayOneShot(atWindowScare);
        }
        if (queenPos.activeSelf && !queenHasBeenFlashed)
        {
            queenHasBeenFlashed = true;
            audioSource.volume = 1f;
            audioSource.PlayOneShot(atWindowScare);
        }
    }

    private void OnMouseDrag()
    {
        if (!threatPresent)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.GetComponent<SpriteRenderer>().sprite = light;
        }
        if (kingPos.activeSelf && !kingHasBeenFlashed)
        {
            kingHasBeenFlashed = true;
            audioSource.volume = 1f;
            audioSource.PlayOneShot(atWindowScare);
        }
        if (queenPos.activeSelf && !queenHasBeenFlashed)
        {
            queenHasBeenFlashed = true;
            audioSource.volume = 1f;
            audioSource.PlayOneShot(atWindowScare);
        }
    }

    private void OnMouseUp()
    {
        flashLightOn = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        gameObject.GetComponent<SpriteRenderer>().sprite = darkness;
    }
}
