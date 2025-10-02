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
    public GameObject office;
    public GameObject blackScreen;
    public GameObject powerOutScreen;
    public GameObject hideOnPowerOut;
    public GameObject windowDarkness;
    public GameObject camButton;
    public GameObject leftDoor;
    public GameObject window;
    public GameObject fadeToBlack;
    public GameObject officeAmbiance;
    public GameObject usageBackground;
    public GameObject princessScreen;
    public GameObject princessFadeToBlack;
    public GameObject princessButton;
    public GameObject mimicJumpscare;
    public GameObject jester;
    public GameObject king;
    public GameObject queen;
    public GameObject knight;
    public TextMeshProUGUI time;  
    public TextMeshProUGUI power;
    public GameObject fan;
    public AudioClip helloSFX;
    public AudioClip knockSFX;
    private AudioSource audioSource;
    private int usage = 1;
    private int currentTime = 0;
    public float currentPower = 999;
    public float interval;
    private int powerToDisplay = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("UpdateTime", 60, 60);
        InvokeRepeating("UpdatePower", 1,1);
        InvokeRepeating("ActivatePrincessButton", 60, 60);
        StartCoroutine(BeginningFlash());
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraSystem.activeSelf)
        {
            time.gameObject.SetActive(true);
            power.gameObject.SetActive(true);
            usageBackground.SetActive(false);
        }
        else if (!cameraSystem.activeSelf)
        {
            time.gameObject.SetActive(false);
            power.gameObject.SetActive(false);
            usageBackground.SetActive(true);
        }

        if (usage == 1)
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

    public void ActivatePrincessButton()
    {
        if (office.GetComponent<Office>().isDoorOpen)
        {
            audioSource.PlayOneShot(helloSFX);
        }
        else
        {
            audioSource.PlayOneShot(knockSFX);
        }
            princessButton.SetActive(true);
        StartCoroutine(KillTimer());
    }

    IEnumerator KillTimer()
    {
        yield return new WaitForSeconds(10);
        if (!princessFadeToBlack.activeSelf && !princessScreen.activeSelf)
        {
            if (cameraSystem.activeSelf)
            {
                cameraSystem.GetComponent<CameraSystem>().SwitchToOffice();
            }
            mimicJumpscare.SetActive(true);
        }
    }

    public void PrincessCoroutineStart()
    {
        if (!office.GetComponent<Office>().isDoorOpen)
        {
            office.GetComponent<Office>().ToggleLeftDoor();
        }
        jester.GetComponent<Jester>().CancelInvoke();
        king.GetComponent<King>().CancelInvoke();
        queen.GetComponent<Queen>().CancelInvoke();
        knight.GetComponent<Knight>().CancelInvoke();
        StartCoroutine(StartPrincessGame());
    }

    public IEnumerator StartPrincessGame()
    {
        Color tempColor = princessFadeToBlack.GetComponent<SpriteRenderer>().color;
        tempColor.a = 0;
        princessFadeToBlack.GetComponent<SpriteRenderer>().color = tempColor;
        princessFadeToBlack.SetActive(true);
        
        yield return new WaitForSeconds(2);
        princessScreen.SetActive(true);
        princessFadeToBlack.SetActive(false);
        office.SetActive(false);
        hideOnPowerOut.SetActive(false);
        
    }

    public IEnumerator BeginningFlash()
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
            fan.GetComponent<Animator>().enabled = false;
            powerOutScreen.SetActive(true);
            officeAmbiance.SetActive(false);
            hideOnPowerOut.SetActive(false);
            windowDarkness.GetComponent<BoxCollider2D>().enabled = false;
            windowDarkness.GetComponent<PolygonCollider2D>().enabled = false;
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
