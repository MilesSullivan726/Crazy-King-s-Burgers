using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UI : MonoBehaviour
{
    public GameObject use2;
    public GameObject use3;
    public GameObject use4;
    public GameObject lurkerJumpscare;
    public GameObject cameraSystem;
    public GameObject blackScreen;
    public GameObject powerOutScreen;
    public GameObject hideOnPowerOut;
    public GameObject camButton;
    public GameObject leftDoor;
    public GameObject window;
    public GameObject fadeToBlack;
    public GameObject officeAmbiance;
    public TextMeshProUGUI time;  
    public TextMeshProUGUI power;
    private int usage = 1;
    private int currentTime = 0;
    public float currentPower = 999;
    public float interval;
    private int powerToDisplay = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("UpdateTime", 60, 60);
        InvokeRepeating("UpdatePower", 1,1);
        StartCoroutine(BeginningFlash());
    }

    // Update is called once per frame
    void Update()
    {

        

        if(usage == 1)
        {
            use2.SetActive(false);
            use3.SetActive(false);
            use4.SetActive(false);
        }
        else if (usage == 2)
        {
            use2.SetActive(true);
            use3.SetActive(false);
            use4.SetActive(false);
        }
        else if (usage == 3)
        {
            use2.SetActive(true);
            use3.SetActive(true);
            use4.SetActive(false);
        }
        else if (usage == 4)
        {
            use2.SetActive(true);
            use3.SetActive(true);
            use4.SetActive(true);
        }
    }

    IEnumerator BeginningFlash()
    {
        yield return new WaitForSeconds(interval);
        blackScreen.SetActive(false);
        yield return new WaitForSeconds(interval);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(interval);
        blackScreen.SetActive(false);
        yield return new WaitForSeconds(interval);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(interval);
        blackScreen.SetActive(false);
        yield return new WaitForSeconds(interval);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(interval);
        blackScreen.SetActive(false);
    }
    public void AddUsage()
    {
        if (usage < 5)
        {
            usage += 1;
        }
    }
    public void SubtractUsage()
    {
        if (usage > 1)
        {
            usage -= 1;
        }
    }

    void UpdateTime()
    {
        currentTime += 1;
        time.text = currentTime.ToString() + "am";
        if(currentTime == 6)
        {
            fadeToBlack.SetActive(true);
            StartCoroutine(Victory());
        }
    }

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Victory");
    }

    void UpdatePower()
    {
        currentPower -= usage;
        currentPower -= 0.7f;
        powerToDisplay = (int)Mathf.Round(currentPower / 10);
        power.text = "Power: " + powerToDisplay.ToString() + "%";
        if(currentPower <= 0)
        {
            cameraSystem.GetComponent<CameraSystem>().SwitchToOffice();
            powerOutScreen.SetActive(true);
            officeAmbiance.SetActive(false);
            hideOnPowerOut.SetActive(false);
            camButton.SetActive(false);
            leftDoor.GetComponent<Animator>().SetTrigger("OpenDoor");
            window.GetComponent<Animator>().SetTrigger("DoorOpen");
            StartCoroutine(PowerOutKill());
            //lurkerJumpscare.SetActive(true);
        }
    }

    IEnumerator PowerOutKill()
    {
        yield return new WaitForSeconds(Random.Range(6, 14));
        lurkerJumpscare.SetActive(true);
    }

}
