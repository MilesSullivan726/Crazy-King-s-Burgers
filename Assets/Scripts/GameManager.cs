using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{

    public GameObject camStatic;
    public GameObject fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FixStaticVideo());
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            StartCoroutine(BackToMenu());
        }
        if (SceneManager.GetActiveScene().name == "Victory")
        {
            StartCoroutine(Victory());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(6);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(8);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator FixStaticVideo()
    {
        camStatic.GetComponent<VideoPlayer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        camStatic.GetComponent<VideoPlayer>().enabled = true;
    }

    public void BeginCurrentNight()
    {
        StartCoroutine(FadeOutAndStart());
    }

    public void BeginCustomNight()
    {
        StartCoroutine(FadeOutAndStartCustomNight());
    }

    IEnumerator FadeOutAndStart()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Night 1");

    }

    IEnumerator FadeOutAndStartCustomNight()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Custom Night");

    }

    public void RestartLastNight()
    {
        SceneManager.LoadScene("Night 1");
    }
}
