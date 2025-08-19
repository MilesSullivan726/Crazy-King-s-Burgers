using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour
{
    private Transform stageRoom;
    private Transform intersection;
    private Transform hallway;
    private Transform ballpit;
    private Transform bathroom;
    private Transform princessRoom;
    private AudioSource audioSource;
    private bool isOnCam02 = false;
    public GameObject officeCanvas;
    public GameObject ui;
    public GameObject staticEffect;
    public GameObject camStatic;
    public GameObject camButton1;
    public GameObject camButton2;
    public GameObject camButton3;
    public GameObject camButton4;
    public GameObject camButton5;
    public GameObject camButton6;
    public GameObject helpButton;
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
        princessRoom = gameObject.transform.Find("princessRoom");
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
        helpButton.GetComponent<HelpButton>().charOnScreen.Clear();
        if (helpButton.GetComponent<HelpButton>().camLurkerActive == false)
        {
            helpButton.GetComponent<HelpButton>().testText.text = string.Empty;
            helpButton.GetComponent<HelpButton>().listIndex = 0;
            
            helpButton.SetActive(false);
        }
        stageRoom.gameObject.SetActive(false);
        intersection.gameObject.SetActive(false);
        hallway.gameObject.SetActive(false);
        ballpit.gameObject.SetActive(false);
        bathroom.gameObject.SetActive(false);
        princessRoom.gameObject.SetActive(false);
        camButton1.GetComponent<Image>().color = Color.black;
        camButton2.GetComponent<Image>().color = Color.black;
        camButton3.GetComponent<Image>().color = Color.black;
        camButton4.GetComponent<Image>().color = Color.black;
        camButton5.GetComponent<Image>().color = Color.black;
        camButton6.GetComponent<Image>().color = Color.black;
    }

    public void SwitchToOffice()
    {
        camStatic.GetComponent<VideoPlayer>().targetCamera = null;
        ui.GetComponent<UI>().SubtractUsage();
        officeCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    IEnumerator CamAnim()
    {
        yield return new WaitForSeconds(0.2f);
        camStatic.GetComponent<VideoPlayer>().targetCamera = Camera.main;
        ui.GetComponent<UI>().AddUsage();
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
        camName.text = "South Hall";
        HideAllRooms();
        camButton1.GetComponent<Image>().color = Color.yellow;
        hallway.gameObject.SetActive(true);

    }

    public void ClickCam2()
    {
        camButton2.GetComponent<Image>().color = Color.yellow;
        StartCoroutine(ShowStatic());
        
        isOnCam02 = true;
        HideAllRooms();
        camButton2.GetComponent<Image>().color = Color.yellow;
        intersection.gameObject.SetActive(true);
    }

    public void ClickCam6()
    {
        
        StartCoroutine(ShowStatic());
        
        isOnCam02 = false;
        camName.text = "Bathrooms";
        HideAllRooms();
        camButton3.GetComponent<Image>().color = Color.yellow;
        bathroom.gameObject.SetActive(true);
    }

    public void ClickCam7()
    {
        
        StartCoroutine(ShowStatic());
        
        isOnCam02 = false;
        camName.text = "Stage Room";
        HideAllRooms();
        camButton4.GetComponent<Image>().color = Color.yellow;
        stageRoom.gameObject.SetActive(true);
    }

    public void ClickCam8()
    {
        
        StartCoroutine(ShowStatic());
        
        isOnCam02 = false;
        camName.text = "Play Area";
        HideAllRooms();
        camButton5.GetComponent<Image>().color = Color.yellow;
        ballpit.gameObject.SetActive(true);
    }

    public void ClickCam9()
    {

        StartCoroutine(ShowStatic());

        isOnCam02 = false;
        camName.text = "Princess Corner";
        HideAllRooms();
        camButton6.GetComponent<Image>().color = Color.yellow;
        princessRoom.gameObject.SetActive(true);
    }
}
