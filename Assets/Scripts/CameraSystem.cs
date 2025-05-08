using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraSystem : MonoBehaviour
{
    private Transform stageRoom;
    private Transform intersection;
    private Transform hallway;
    private Transform ballpit;
    private Transform bathroom;
    private AudioSource audioSource;
    private bool isOnCam02 = false;
    public GameObject officeCanvas;
    public GameObject ui;
    public GameObject staticEffect;
    public TextMeshProUGUI camName;
    public AudioClip switchCamSFX;

    // Start is called before the first frame update
    void Start()
    {
        stageRoom = gameObject.transform.Find("Stageroom");
        intersection = gameObject.transform.Find("Rooms 2-5");
        hallway = gameObject.transform.Find("hallway");
        ballpit = gameObject.transform.Find("ballpit");
        bathroom = gameObject.transform.Find("bathroom");
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnCam02)
        {
            camName.text = intersection.gameObject.GetComponent<Cam02>().currentCamName;
        }
    }

    void HideAllRooms()
    {
        stageRoom.gameObject.SetActive(false);
        intersection.gameObject.SetActive(false);
        hallway.gameObject.SetActive(false);
        ballpit.gameObject.SetActive(false);
        bathroom.gameObject.SetActive(false);
    }

    public void SwitchToOffice()
    {
        ui.GetComponent<UI>().SubtractUsage();
        officeCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public IEnumerator ShowStatic()
    {
        audioSource.PlayOneShot(switchCamSFX);
        staticEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        staticEffect.SetActive(false);
    }

    public void ClickCam1()
    {
        StartCoroutine(ShowStatic());
        
        isOnCam02 = false;
        camName.text = "South Hallway";
        HideAllRooms();
        hallway.gameObject.SetActive(true);

    }

    public void ClickCam2()
    {
        StartCoroutine(ShowStatic());
        
        isOnCam02 = true;
        HideAllRooms();
        intersection.gameObject.SetActive(true);
    }

    public void ClickCam6()
    {
        StartCoroutine(ShowStatic());
        
        isOnCam02 = false;
        camName.text = "Bathrooms";
        HideAllRooms();
        bathroom.gameObject.SetActive(true);
    }

    public void ClickCam7()
    {
        StartCoroutine(ShowStatic());
        
        isOnCam02 = false;
        camName.text = "Stage Room";
        HideAllRooms();
        stageRoom.gameObject.SetActive(true);
    }

    public void ClickCam8()
    {
        StartCoroutine(ShowStatic());
        
        isOnCam02 = false;
        camName.text = "Play Area";
        HideAllRooms();
        ballpit.gameObject.SetActive(true);
    }
}
