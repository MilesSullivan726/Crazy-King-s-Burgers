using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Office : MonoBehaviour
{
    public GameObject camSystem;
    public GameObject leftDoor;
    public GameObject windowDoor;
    public GameObject ui;
    public GameObject camStatic;
    public GameObject windowButton;
    public GameObject leftDoorButton;
    public AudioClip leftDoorSFX;
    public AudioClip windowDoorSFX; 

    private AudioSource audioSource;

    public bool isWindowOpen = true;
    public bool isDoorOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FixStaticVideo());
        isDoorOpen = true;
        isWindowOpen = true;
        audioSource = GetComponent<AudioSource>();
        
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

    public void SwitchToCams()
    {
        StartCoroutine(CamAnim());
    }

    IEnumerator CamAnim()
    {
        yield return new WaitForSeconds(0.4f);
        camStatic.GetComponent<VideoPlayer>().targetCamera = Camera.main;
        ui.GetComponent<UI>().AddUsage();
        camSystem.SetActive(true);
        gameObject.SetActive(false);
    }

    IEnumerator LeftDoorCooldown()
    {
        leftDoorButton.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        leftDoorButton.GetComponent<Button>().enabled = true;
    }
    public void ToggleLeftDoor()
    {
        
        audioSource.PlayOneShot(leftDoorSFX);
        if (!isDoorOpen)
        {
            StartCoroutine(LeftDoorCooldown());
            ui.GetComponent<UI>().SubtractUsage();
            leftDoor.GetComponent<Animator>().SetTrigger("OpenDoor");
            //leftDoor.SetActive(false);
            isDoorOpen = true;
            
        }
        else
        {
            ui.GetComponent<UI>().AddUsage();
            leftDoor.GetComponent<Animator>().SetTrigger("CloseDoor");
            //leftDoor.SetActive(true);
            isDoorOpen = false;
        }
    }

    IEnumerator WindowCooldown()
    {
        windowButton.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        windowButton.GetComponent<Button>().enabled = true;
    }

    public void ToggleWindowDoor()
    {
        StartCoroutine(WindowCooldown());
        audioSource.PlayOneShot(windowDoorSFX);
        if (!isWindowOpen)
        {
            ui.GetComponent<UI>().SubtractUsage();
            //windowDoor.SetActive(false);
            windowDoor.GetComponent<Animator>().SetTrigger("DoorOpen");
            isWindowOpen = true;
        }
        else
        {
            ui.GetComponent<UI>().AddUsage();
            //windowDoor.SetActive(true);
            windowDoor.GetComponent<Animator>().SetTrigger("DoorClose");
            isWindowOpen = false;
        }
        
    }
}
