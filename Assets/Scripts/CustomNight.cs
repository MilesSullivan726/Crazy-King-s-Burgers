using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CustomNight : MonoBehaviour
{

    
    public GameObject camStatic;
    public GameObject fadeOut;
    public GameObject kingAi;
    public GameObject queenAi;
    public GameObject jesterAi;
    public GameObject camLurkAi;
    public GameObject night;
    public TextMeshProUGUI kingText;
    public TextMeshProUGUI queenText;
    public TextMeshProUGUI jesterText;
    public TextMeshProUGUI camLurkText;
    public int kingValue;
    public int queenValue;
    public int jesterValue;
    public int camLurkValue;

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

    public void BackToMenu()
    {
        fadeOut.SetActive(true);
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TitleScreen");
    }

    public void KingDown()
    {
        if(kingValue == 0)
        {
            kingValue = 20;
            kingText.text = kingValue.ToString();
        }
        else if(kingValue > 0)
        {
            kingValue -= 1;
            kingText.text = kingValue.ToString();
        }
    }

    public void KingUp()
    {
        if (kingValue == 20)
        {
            kingValue = 0;
            kingText.text = kingValue.ToString();
        }
        else if (kingValue < 20)
        {
            kingValue += 1;
            kingText.text = kingValue.ToString();
        }
    }

    public void QueenDown()
    {
        if (queenValue == 0)
        {
            queenValue = 20;
            queenText.text = queenValue.ToString();
        }
        
        else if (queenValue > 0)
        {
            queenValue -= 1;
            queenText.text = queenValue.ToString();
        }
    }

    public void QueenUp()
    {
        if (queenValue == 20)
        {
            queenValue = 0;
            queenText.text = queenValue.ToString();
        }

        else if (queenValue < 20)
        {
            queenValue += 1;
            queenText.text = queenValue.ToString();
        }
    }

    public void JesterDown()
    {
        if (jesterValue == 0)
        {
            jesterValue = 20;
            jesterText.text = jesterValue.ToString();
        }
        
        else if (jesterValue > 0)
        {
            jesterValue -= 1;
            jesterText.text = jesterValue.ToString();
        }
    }


    public void JesterUp()
    {
        if (jesterValue == 20)
        {
            jesterValue = 0;
            jesterText.text = jesterValue.ToString();
        }

        else if (jesterValue < 20)
        {
            jesterValue += 1;
            jesterText.text = jesterValue.ToString();
        }
    }

    public void CamLurkDown()
    {
        if(camLurkValue == 0)
        {
            camLurkValue = 20;
            camLurkText.text = camLurkValue.ToString();
        }
        else if (camLurkValue > 0)
        {
            camLurkValue -= 1;
            camLurkText.text = camLurkValue.ToString();
        }
    }

    public void CamLurkUp()
    {
        if (camLurkValue == 20)
        {
            camLurkValue = 0;
            camLurkText.text = camLurkValue.ToString();
        }
        else if (camLurkValue < 20)
        {
            camLurkValue += 1;
            camLurkText.text = camLurkValue.ToString();
        }
    }

    public void BeginNight()
    {
        kingAi.GetComponent<Queen>().difficulty = kingValue;
        queenAi.GetComponent<King>().difficulty = queenValue;
        jesterAi.GetComponent<Jester>().difficulty = jesterValue;
        camLurkAi.GetComponent<CamLurker>().difficulty = camLurkValue;
        StartCoroutine(StartNight());
    }

    IEnumerator StartNight()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(false);
        camStatic.SetActive(false);
        night.SetActive(true);
        gameObject.SetActive(false);
    }
}
