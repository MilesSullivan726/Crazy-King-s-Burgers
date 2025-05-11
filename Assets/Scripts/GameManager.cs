using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{

    public GameObject camStatic;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FixStaticVideo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FixStaticVideo()
    {
        camStatic.GetComponent<VideoPlayer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        camStatic.GetComponent<VideoPlayer>().enabled = true;
    }

    public void BeginCurrentNight()
    {
        SceneManager.LoadScene("Night 1");
    }

    public void RestartLastNight()
    {
        SceneManager.LoadScene("Night 1");
    }
}
