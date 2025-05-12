using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{

    public GameObject flashingScreen;
    public GameObject tablet;
    public GameObject fadeOut;
    static bool turnOffFlash = false;

    // Start is called before the first frame update
    void Start()
    {
        tablet.SetActive(false);
        StartCoroutine(Shake());
        StartCoroutine("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableFlash()
    {
        turnOffFlash = true;
        fadeOut.SetActive(true);
        StartCoroutine(GoToMainMenu());
    }

    public void EnableFlash()
    {
        turnOffFlash = false;
        fadeOut.SetActive(true);
        StartCoroutine(GoToMainMenu());
    }

    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator Shake()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.localPosition = new Vector3(0.7f, transform.localPosition.y, transform.localPosition.z);
            if (!turnOffFlash)
            {
                flashingScreen.SetActive(true);
            }
            yield return new WaitForSeconds(0.025f);
            transform.localPosition = new Vector3(0.9f, transform.localPosition.y, transform.localPosition.z);
            if (!turnOffFlash)
            {
                flashingScreen.SetActive(false);
            }
            yield return new WaitForSeconds(0.025f);
        }
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");

    }
}
