using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CamLurker : MonoBehaviour
{
    public GameObject[] Positions;
    public GameObject killButton;
    public GameObject ui;
    public GameObject lurkerTextBox;
    public TextMeshProUGUI lurkText;
    public int difficulty;
    public bool buttonClicked;
    private int moveChance;
    private GameObject currentPos;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Movement", 10, 12);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Movement()
    {
        for (int i = 0; i < Positions.Length; i++) 
        {
            Positions[i].SetActive(false);
        }
        moveChance = Random.Range(0, 21);
        if (moveChance <= difficulty)
        {
            lurkerTextBox.SetActive(true);
            lurkText.text = "Psst... Come find me!";
            
            currentPos = Positions[Random.Range(0, 4)];
            currentPos.SetActive(true);
            killButton.SetActive(true);
            StartCoroutine("StartTimer");
        }

    }

    public void RemoveThreat()
    {
        buttonClicked = true;
        if (currentPos.transform.parent.gameObject.activeSelf)
        {
            currentPos.SetActive(false);
            killButton.SetActive(false);
            lurkerTextBox.SetActive(false);
        }
        else
        {
            currentPos.SetActive(false);
            killButton.SetActive(false);
            ui.GetComponent<UI>().currentPower -= 50;
            lurkText.text = "Better luck next time!";
            StartCoroutine("HideTextBox");
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(7);
        if (!buttonClicked) 
        {
            currentPos.SetActive(false);
            killButton.SetActive(false);
            ui.GetComponent<UI>().currentPower -= 50;
            lurkText.text = "Better luck next time!";
            StartCoroutine("HideTextBox");
        }
        buttonClicked = false;
    }

    IEnumerator HideTextBox()
    {
        yield return new WaitForSeconds(3);
        lurkerTextBox.SetActive(false);
    }
}
