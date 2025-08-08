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
    public GameObject testTextBox;
    public GameObject triangle;
    public Button helpButton;
    public TextMeshProUGUI testText;
    public TextMeshProUGUI buttonText;
    public string charOnScreen = "Test";
    public string[] hints;
    private bool isOnScreen = false;
    private TextMeshProUGUI noText;
    private SpriteRenderer boxSprite;
    private SpriteRenderer triangleSprite;
    // Start is called before the first frame update
    void Start()
    {
        testText.text = string.Empty;
        boxSprite = testTextBox.GetComponent<SpriteRenderer>();
        triangleSprite = triangle.GetComponent<SpriteRenderer>();
        buttonText.text = "HELP!";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopUp()
    {
        StartCoroutine(ButtonFlash());
        if (!isOnScreen)
        {
            evaAnimator.SetBool("isOnScreen", true);
            isOnScreen = true;
            StartCoroutine(HelpButtonCooldown(3));
            StartCoroutine(ShowTextBox(testTextBox));
        }
        else
        {
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

        // show characters 1 by 1
        foreach (char c in hints[0].ToCharArray())
        {
            
            testText.text += c;
            yield return new WaitForSeconds(0.03f);

        }
        buttonText.text = "OK!";
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
        Color resetAlpha = boxSprite.color;
        resetAlpha.a = 0;
        boxSprite.color = resetAlpha;
        triangleSprite.color = resetAlpha;
    }
}
