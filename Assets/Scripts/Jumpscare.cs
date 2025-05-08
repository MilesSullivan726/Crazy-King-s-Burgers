using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");

    }
}
