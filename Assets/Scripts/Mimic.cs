using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    public GameObject[] positions;
    public GameObject office;
    public GameObject jumpscare;
    public GameObject cameraSystem;
    public GameObject windowDarkness;
    public AudioClip doorKnock;
    
    public int difficulty;
    public bool knightOverride = false;
    public bool knightPresent = false;
    private int moveChance;
    public int currentPos = 1;
    private AudioSource audioSource;
    public int finalPos = 6;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Movement", 9, 9);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement()
    {
        Debug.Log(currentPos);
        moveChance = Random.Range(1, 21);
        if ((moveChance <= difficulty && currentPos != finalPos && !knightPresent) || knightOverride)
        {
            knightOverride = false;
            if (positions[currentPos].transform.parent.gameObject.activeSelf || positions[currentPos - 1].transform.parent.gameObject.activeSelf)
            {
                StartCoroutine(cameraSystem.GetComponent<CameraSystem>().ShowStatic());
            }
            if (currentPos == 3 || currentPos == 4)
            {
                StartCoroutine(windowDarkness.GetComponent<Flashlight>().HallwayFlash());

            }
            if (currentPos == 4)
            {
                currentPos = Random.Range(4, 6);
                
                if(currentPos == 4)
                {
                    finalPos = 5;
                }
                else
                {
                    finalPos = 7;
                }
                    

            }
            if (currentPos == 5)
            {
                positions[currentPos - 2].SetActive(false);
                positions[currentPos].SetActive(true);
                currentPos += 1;
                
            }
            else
            {
                positions[currentPos - 1].SetActive(false);
                positions[currentPos].SetActive(true);
                currentPos += 1;
                
            }
        }
        else if (currentPos == finalPos)
        {
            if ((office.GetComponent<Office>().isWindowOpen && currentPos == 5) || (office.GetComponent<Office>().isDoorOpen && currentPos == 7))
            {
                cameraSystem.GetComponent<CameraSystem>().SwitchToOffice();
                jumpscare.SetActive(true);

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
}
