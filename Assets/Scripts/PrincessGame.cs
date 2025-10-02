using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrincessGame : MonoBehaviour
{
    private int isMimic;
    private int talkDialogue;
    private int question;
    private int mimicHint;
    private int count;
    private Coroutine currentDialogue;
    public AudioSource audioSource;
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI timer;
    public SpriteRenderer portrait;
    public Sprite princessPortrait;
    public Sprite mimicPortrait;
    public string[] dialogue;
    public GameObject jester;
    public GameObject king;
    public GameObject queen;
    public GameObject knight;
    public GameObject mimic;
    public GameObject ui;
    public GameObject office;
    public GameObject mimicJumpscare;
    public GameObject princessOffice;
    public GameObject mimicStartPos;
    public GameObject hideOnPowerOut;
    public GameObject button;
    public GameObject fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        fadeIn.SetActive(true);
        StartCoroutine(FadeIn());
        timer.text = "40";
        count = 40;
        StartCoroutine(Timer());
        jester.GetComponent<Jester>().CancelInvoke();
        king.GetComponent<King>().CancelInvoke();
        queen.GetComponent<Queen>().CancelInvoke();
        knight.GetComponent<Knight>().CancelInvoke();
        ui.GetComponent<UI>().CancelInvoke();
        isMimic = Random.Range(0, 2); // 0 is Princess, 1 is Mimic
        if (isMimic == 1) 
            {
                mimicHint = Random.Range(0, 3); // 0 is image, 1 is talk, 2 is question
            
            }
        if (isMimic == 1 && mimicHint == 0)
        {
            portrait.sprite = mimicPortrait;
        }
        else
        {
            portrait.sprite = princessPortrait;
        }
        if (isMimic == 1 && mimicHint == 1)
        {
            talkDialogue = Random.Range(1, 4); // Determine what dialogue is displayed when "Talk" is selected
        }
        else
        {
            talkDialogue = Random.Range(4, 7); // Determine what dialogue is displayed when "Talk" is selected
        }
        if (isMimic == 1 && mimicHint == 2)
        {
            question = Random.Range(7, 10); // Determine what dialogue is displayed when "Question" is selected
        }
        else
        {
            question = Random.Range(10, 13); // Determine what dialogue is displayed when "Question" is selected
        }


        currentDialogue = StartCoroutine(DisplayText(0));
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(2);
        fadeIn.SetActive(false);
        Color tempColor = fadeIn.GetComponent<SpriteRenderer>().color;
        tempColor.a = 1;
        fadeIn.GetComponent<SpriteRenderer>().color = tempColor;
    }

    IEnumerator DisplayText(int index)
    {
        textBox.text = string.Empty;
        foreach (char c in dialogue[index].ToCharArray())
        {
            audioSource.Play();
            textBox.text += c;
            yield return new WaitForSeconds(0.03f);

        }
    }

    IEnumerator Timer()
    {
        while (count != 0)
        {
            yield return new WaitForSeconds(1);
            count -= 1;
            timer.text = count.ToString();
        }
        office.SetActive(true);
        hideOnPowerOut.SetActive(true);
        mimicJumpscare.SetActive(true);
        button.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Talk()
    {
        StopCoroutine(currentDialogue);
        
        currentDialogue = StartCoroutine(DisplayText(talkDialogue));


    }
    public void Question()
    {
        StopCoroutine(currentDialogue);
        currentDialogue = StartCoroutine(DisplayText(question));


    }

    public void LetIn()
    {
        if (isMimic == 1)
        {
            office.SetActive(true);
            hideOnPowerOut.SetActive(true);
            mimicJumpscare.SetActive(true);
            button.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            princessOffice.SetActive(true);
            office.SetActive(true);
            hideOnPowerOut.SetActive(true);
            button.SetActive(false);
            jester.GetComponent<Jester>().InvokeRepeating("Movement", 11, 11);
            king.GetComponent<King>().InvokeRepeating("Movement", 9, 9);
            queen.GetComponent<Queen>().InvokeRepeating("Movement", 10, 10);
            knight.GetComponent<Knight>().InvokeRepeating("Movement", 20, 20);
            ui.GetComponent<UI>().InvokeRepeating("UpdateTime", 60, 60);
            ui.GetComponent<UI>().InvokeRepeating("UpdatePower", 1, 1);
            ui.GetComponent<UI>().princessButton.SetActive(false);
            

            jester.GetComponent<Jester>().difficulty -= 3;
            king.GetComponent<King>().difficulty -= 3;
            queen.GetComponent<Queen>().difficulty -= 3;
            knight.GetComponent<Knight>().difficulty -= 3;
            mimic.GetComponent<Mimic>().difficulty += 5;
            if (mimic.GetComponent<Mimic>().difficulty >= 20)
            {
                mimic.GetComponent<Mimic>().difficulty = 20;
            }
            mimic.GetComponent<Mimic>().InvokeRepeating("Movement", 9, 9);
            mimicStartPos.SetActive(true);
            gameObject.SetActive(false);

        }
    }

    public void ShutOut()
    {
        if(isMimic == 1)
        {
            office.SetActive(true);
            hideOnPowerOut.SetActive(true);
            office.GetComponent<Office>().ToggleLeftDoor();
            button.SetActive(false);
            ui.GetComponent<UI>().princessButton.SetActive(false);
            ui.GetComponent<UI>().InvokeRepeating("ActivatePrincessButton", 60, 60);
            jester.GetComponent<Jester>().InvokeRepeating("Movement", 11, 11);
            king.GetComponent<King>().InvokeRepeating("Movement", 9, 9);
            queen.GetComponent<Queen>().InvokeRepeating("Movement", 10, 10);
            knight.GetComponent<Knight>().InvokeRepeating("Movement", 20, 20);
            ui.GetComponent<UI>().InvokeRepeating("UpdateTime", 60, 60);
            ui.GetComponent<UI>().InvokeRepeating("UpdatePower", 1, 1);
            gameObject.SetActive(false);
        }
        else
        {
            office.SetActive(true);
            hideOnPowerOut.SetActive(true);
            button.SetActive(false);
            office.GetComponent<Office>().ToggleLeftDoor();
            jester.GetComponent<Jester>().InvokeRepeating("Movement", 11, 11);
            king.GetComponent<King>().InvokeRepeating("Movement", 9, 9);
            queen.GetComponent<Queen>().InvokeRepeating("Movement", 10, 10);
            knight.GetComponent<Knight>().InvokeRepeating("Movement", 20, 20);
            ui.GetComponent<UI>().InvokeRepeating("UpdateTime", 60, 60);
            ui.GetComponent<UI>().InvokeRepeating("UpdatePower", 1, 1);

            jester.GetComponent<Jester>().difficulty += 4;
            if (jester.GetComponent<Jester>().difficulty >= 20)
            {
                jester.GetComponent<Jester>().difficulty = 20;
            }
            king.GetComponent<King>().difficulty += 4;
            if (king.GetComponent<King>().difficulty >= 20)
            {
                king.GetComponent<King>().difficulty = 20;
            }
            queen.GetComponent<Queen>().difficulty += 4;
            if (queen.GetComponent<Queen>().difficulty >= 20)
            {
                queen.GetComponent<Queen>().difficulty = 20;
            }
            knight.GetComponent<Knight>().difficulty += 4;
            if (knight.GetComponent<Knight>().difficulty >= 20)
            {
                knight.GetComponent<Knight>().difficulty = 20;
            }
            mimic.GetComponent<Mimic>().difficulty -= 3;
            mimic.GetComponent<Mimic>().InvokeRepeating("Movement", 9, 9);
            ui.GetComponent<UI>().princessButton.SetActive(false);
            mimicStartPos.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
