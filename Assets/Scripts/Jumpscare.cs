using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{

    public GameObject flashingScreen;
    public GameObject tablet;

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

    IEnumerator Shake()
    {
        for (int i = 0; i < 30; i++)
        {
            transform.localPosition = new Vector3(0.7f, transform.localPosition.y, transform.localPosition.z);
            flashingScreen.SetActive(true);
            yield return new WaitForSeconds(0.025f);
            transform.localPosition = new Vector3(0.9f, transform.localPosition.y, transform.localPosition.z);
            flashingScreen.SetActive(false);
            yield return new WaitForSeconds(0.025f);
        }
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");

    }
}
