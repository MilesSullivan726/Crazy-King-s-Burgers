using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public GameObject[] positions;
    public GameObject office;
    public GameObject jumpscare;
    public GameObject cameraSystem;
    public GameObject windowDarkness;
    public GameObject vent;
    public GameObject queenPos;
    public GameObject jesterPos;
    public GameObject kingPos1;
    public GameObject kingPos2;
    public GameObject queenAI;
    public GameObject kingAI;
    public GameObject jesterAI;
    public AudioClip doorKnock;
    public AudioClip run;
    public int difficulty;
    private int moveChance;
    private int currentPos = 0;
    private int attackPos;
   
    private AudioSource audioSource;
    public int finalPos = 6;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Movement", 20, 20);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Movement();
        }
        if (jesterAI.GetComponent<Jester>().currentPos == 2 && currentPos == 1)
        {
            jesterAI.GetComponent<Jester>().knightPresent = true;
        }
        else if (queenAI.GetComponent<Queen>().currentPos == 3 && currentPos == 2)
        {
            queenAI.GetComponent<Queen>().knightPresent = true;

        }
        else if (kingAI.GetComponent<King>().currentPos == 2 && currentPos == 3)
        {
            kingAI.GetComponent<King>().knightPresent = true;

        }
    }

    void Movement()
    {
        moveChance = Random.Range(1, 21);
        if (moveChance <= difficulty)
        {
            if (positions[currentPos].transform.parent.gameObject.activeSelf)
            {
                StartCoroutine(cameraSystem.GetComponent<CameraSystem>().ShowStatic());
            }
            if (currentPos == 0) //start
            {
                positions[0].SetActive(false);
                attackPos = Random.Range(1, 4);
                
                if (attackPos == 1) //left
                {
                    positions[1].SetActive(true);
                    currentPos = 1;
                    if (jesterPos.activeSelf)
                    {
                        jesterAI.GetComponent<Jester>().knightOverride = true;
                        jesterAI.GetComponent<Jester>().Movement();
                    }
                    
                }
                else if (attackPos == 2) //middle
                {
                    positions[2].SetActive(true);
                    currentPos = 2;
                    
                    if (queenPos.activeSelf)
                    {
                        
                        queenAI.GetComponent<Queen>().knightOverride = true;
                        queenAI.GetComponent<Queen>().Movement();
                    }
                    
                }
                else if (attackPos == 3) //right
                {
                    positions[3].SetActive(true);
                    currentPos = 3;
                    
                    if (kingPos2.activeSelf)
                    {
                        kingAI.GetComponent<King>().knightOverride = true;
                        kingAI.GetComponent<King>().Movement();
                        kingAI.GetComponent<King>().knightOverride = true;
                        kingAI.GetComponent<King>().Movement();
                    }
                    else if (kingPos1.activeSelf)
                    {
                        kingAI.GetComponent<King>().knightOverride = true;
                        kingAI.GetComponent<King>().Movement();
                    }
                    
                }
            }
            else if (currentPos == 1)
            {
                audioSource.PlayOneShot(run);
                jesterAI.GetComponent<Jester>().knightPresent = false;
                StartCoroutine(Attack("left"));
            }
            else if (currentPos == 2)
            {
                audioSource.PlayOneShot(run);
                queenAI.GetComponent<Queen>().knightPresent = false;
                StartCoroutine(windowDarkness.GetComponent<Flashlight>().HallwayFlash());
                positions[4].SetActive(true);
                StartCoroutine(Attack("middle"));
            }
            else if (currentPos == 3)
            {
                audioSource.PlayOneShot(run);
                kingAI.GetComponent<King>().knightPresent = false;
                StartCoroutine(Attack("right"));
            }
            
            
            
        }
        
    }
    IEnumerator Attack(string direction)
    {
        currentPos = 0;
        positions[1].SetActive(false);
        positions[2].SetActive(false);
        positions[3].SetActive(false);
        yield return new WaitForSeconds(3);
        if(direction == "left" && office.GetComponent<Office>().isDoorOpen)
        {
            cameraSystem.GetComponent<CameraSystem>().SwitchToOffice();
            jumpscare.SetActive(true);
        }
        else if (direction == "middle" && office.GetComponent<Office>().isWindowOpen)
        {
            cameraSystem.GetComponent<CameraSystem>().SwitchToOffice();
            jumpscare.SetActive(true);
        }
        else if (direction == "right" && !vent.GetComponent<VentDoor>().isClosed)
        {
            cameraSystem.GetComponent<CameraSystem>().SwitchToOffice();
            jumpscare.SetActive(true);
        }
        else
        {
           
            if (positions[0].transform.parent.gameObject.activeSelf)
            {
                StartCoroutine(cameraSystem.GetComponent<CameraSystem>().ShowStatic());
            }
            
            audioSource.PlayOneShot(doorKnock);
            
            
            positions[4].SetActive(false);
            positions[0].SetActive(true);

            
        }
    }
}
