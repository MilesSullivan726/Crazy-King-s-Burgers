using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    public GameObject[] positions;
    public GameObject office;
    public GameObject jumpscare;
    public GameObject cameraSystem;
    public GameObject doorButton;
    public GameObject windowButton;
    public GameObject ui;
    public AudioClip doorKnock;
    public int difficulty;
    public bool knightOverride = false;
    public bool knightPresent = false;
    private int moveChance;
    private bool hasEnteredOffice = false;
    public int currentPos = 1;
    private AudioSource audioSource;
    public int finalPos = 6;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Movement", 11, 11);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement()
    {
        
        moveChance = Random.Range(1, 21);
        if ((moveChance <= difficulty && currentPos != finalPos && !hasEnteredOffice) || knightOverride)
            {
            knightOverride = false;
            if (positions[currentPos].transform.parent.gameObject.activeSelf || positions[currentPos - 1].transform.parent.gameObject.activeSelf)
            {
                StartCoroutine(cameraSystem.GetComponent<CameraSystem>().ShowStatic());
            }
            positions[currentPos - 1].SetActive(false);
            positions[currentPos].SetActive(true);
            currentPos += 1;
        }
        else if (currentPos == finalPos && !hasEnteredOffice)
        {
            if (office.GetComponent<Office>().isDoorOpen)
            {
                hasEnteredOffice = true;
                StartCoroutine(ui.GetComponent<UI>().BeginningFlash());
                doorButton.SetActive(false);
                windowButton.SetActive(false);
                StartCoroutine(ShowArmsInOffice());
                if (!office.GetComponent<Office>().isWindowOpen)
                {
                    office.GetComponent<Office>().ToggleWindowDoor();
                } 

            }
            else
            {
                if (positions[0].transform.parent.gameObject.activeSelf || positions[currentPos - 1].transform.parent.gameObject.activeSelf)
                {
                    StartCoroutine(cameraSystem.GetComponent<CameraSystem>().ShowStatic());
                }
                audioSource.PlayOneShot(doorKnock);
                currentPos = 1;
                positions[finalPos - 1].SetActive(false);
                positions[0].SetActive(true);

            }
        }
    }

    IEnumerator ShowArmsInOffice()
    {
        yield return new WaitForSeconds(0.3f);
        jumpscare.SetActive(true);
    }
}
