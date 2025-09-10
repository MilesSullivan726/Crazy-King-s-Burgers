using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    public Animator evaAnimator;
    public Animator mouth;
    public GameObject testTextBox;
    public GameObject triangle;
    public GameObject[] roomsToHideHint;
    public Button helpButton;
    public TextMeshProUGUI testText;
    public TextMeshProUGUI buttonText;
    public string[] hints;
    public bool camLurkerActive = false;
    public List<string> charOnScreen;
    private List<string> tempCharList;
    public bool isOnScreen = false;
    private bool readyToShowText = false;
    private TextMeshProUGUI noText;
    private SpriteRenderer boxSprite;
    private SpriteRenderer triangleSprite;
    private AudioSource audioSource;
    public int listIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        testText.text = string.Empty;
        boxSprite = testTextBox.GetComponent<SpriteRenderer>();
        triangleSprite = triangle.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        buttonText.text = "HELP!";
        //charOnScreen.Add("Queen");
        //charOnScreen.Add("King");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopUp()
    {
        audioSource.Play();
        
        
        StopAllCoroutines();
        testText.text = string.Empty;
        StartCoroutine(ButtonFlash());
        if (!isOnScreen) //show hint
        {
            evaAnimator.SetBool("isOnScreen", true);
            isOnScreen = true;
            StartCoroutine(HelpButtonCooldown(1));
            StartCoroutine(ShowTextBox(testTextBox));
        }
        else if (roomsToHideHint[0].activeSelf || roomsToHideHint[1].activeSelf || roomsToHideHint[2].activeSelf) // prevents bugs when switching cams when cam lurker hint is active
        {
            
            StartCoroutine(HideEva());
            gameObject.GetComponent<Image>().color = Color.black;
            testText.text = string.Empty;
            listIndex = 0;
            buttonText.text = "HELP!";
            evaAnimator.SetBool("isOnScreen", false);
            isOnScreen = false;
            testText.text = string.Empty;
            StartCoroutine(HelpButtonCooldown(1));
            Color resetAlpha = boxSprite.color;
            resetAlpha.a = 0;
            boxSprite.color = resetAlpha;
            triangleSprite.color = resetAlpha;
            
        }
        else if (listIndex != charOnScreen.Count)
        {
            
            if (camLurkerActive)
            {
                StartCoroutine(LurkerHint());
            }
            else
            {
                StartCoroutine(DisplayText());
            }
        }
        
        else //hide Eva and text
        {
            testText.text = string.Empty;
            listIndex = 0;
            buttonText.text = "HELP!";
            evaAnimator.SetBool("isOnScreen", false);
            isOnScreen = false;
            testText.text = string.Empty;
            StartCoroutine(HelpButtonCooldown(1));
            Color resetAlpha = boxSprite.color;
            resetAlpha.a = 0;
            boxSprite.color = resetAlpha;
            triangleSprite.color = resetAlpha;
            
        }
    }

    IEnumerator HideEva()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    IEnumerator LurkerHint()
    {
        testText.text = string.Empty;
        
        buttonText.text = "OK!";
        // show characters 1 by 1
        foreach (char c in hints[2].ToCharArray())
            {
            audioSource.Play();
            testText.text += c;
                yield return new WaitForSeconds(0.03f);

            }

        


    }

    public IEnumerator DisplayText()
    {

        mouth.SetTrigger("Talk");
        testText.text = string.Empty;
        
        buttonText.text = "OK!";
        if (charOnScreen[listIndex] == "Knight")
        {
            listIndex += 1;
            // show characters 1 by 1
            foreach (char c in hints[4].ToCharArray())
            {
                audioSource.Play();
                testText.text += c;
                yield return new WaitForSeconds(0.03f);

            }

        }
        else if (charOnScreen[listIndex] == "Jester")
        {
            listIndex += 1;
            // show characters 1 by 1
            foreach (char c in hints[3].ToCharArray())
            {
                audioSource.Play();
                testText.text += c;
                yield return new WaitForSeconds(0.03f);

            }
            
        }
        else if (charOnScreen[listIndex] == "Queen")
        {
            listIndex += 1;
            // show characters 1 by 1
            foreach (char c in hints[0].ToCharArray())
            {
                audioSource.Play();
                testText.text += c;
                yield return new WaitForSeconds(0.03f);

            }
            
        }
        else if (charOnScreen[listIndex] == "King")
        {
            listIndex += 1;
            // show characters 1 by 1
            foreach (char c in hints[1].ToCharArray())
            {
                audioSource.Play();
                testText.text += c;
                yield return new WaitForSeconds(0.03f);

            }
            
        }
        mouth.SetTrigger("Close");

    }

    IEnumerator ShowTextBox(GameObject textBox)
    {
        yield return new WaitForSeconds(0.5f);
        
        Color tempColor = boxSprite.color;

        while (tempColor.a < 1)
        {
            tempColor.a += Time.deltaTime / 0.7f;
            boxSprite.color = tempColor;
            triangleSprite.color = tempColor;
            yield return null;
        }
        boxSprite.color = tempColor;
        triangleSprite.color = tempColor;
        

        if (camLurkerActive)
        {
            StartCoroutine(LurkerHint());
        }
        else
        {
            
            StartCoroutine(DisplayText());
        }


    }

    IEnumerator HelpButtonCooldown(float cooldown)
    {
        helpButton.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(cooldown);
        helpButton.GetComponent<Button>().enabled = true;
    }

    IEnumerator ButtonFlash()
    {
        gameObject.GetComponent<Image>().color = Color.yellow;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Image>().color = Color.black;
    }

    private void OnEnable()
    {
        Debug.Log("Help Button");
        charOnScreen = new List<string>();
        buttonText.text = "HELP!";
        helpButton.GetComponent<Button>().enabled = true;
        evaAnimator.SetBool("isOnScreen", false);
        isOnScreen = false;
        testText.text = string.Empty;
        
        Color resetAlpha = boxSprite.color;
        resetAlpha.a = 0;
        boxSprite.color = resetAlpha;
        triangleSprite.color = resetAlpha;
    }

    private void OnDisable()
    {
        testText.text = string.Empty;
        listIndex = 0;
        Color resetAlpha = boxSprite.color;
        resetAlpha.a = 0;
        boxSprite.color = resetAlpha;
        triangleSprite.color = resetAlpha;
    }
}
