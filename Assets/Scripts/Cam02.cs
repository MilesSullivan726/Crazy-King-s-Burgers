using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam02 : MonoBehaviour
{
    private Transform leftHall;
    private Transform intersection;
    private Transform topHall;
    private Transform rightHall;
    private int count = 1;
    public string currentCamName = "Intersection";
    public GameObject border;
    public GameObject camSystem;
    // Start is called before the first frame update
    void Start()
    {
        intersection = gameObject.transform.Find("intersection");
        leftHall = gameObject.transform.Find("leftHall");
        rightHall = gameObject.transform.Find("rightHall");
        topHall = gameObject.transform.Find("topHall");
        InvokeRepeating("RotateCams", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HideAllRooms()
    {
        intersection.gameObject.SetActive(false);
        leftHall.gameObject.SetActive(false);
        topHall.gameObject.SetActive(false);
        rightHall.gameObject.SetActive(false);
    }

    void RotateCams()
    {
        StartCoroutine(camSystem.GetComponent<CameraSystem>().ShowStatic());
        if (count > 4)
        {
            count = 1;
        }
        if(count == 1)
        {
            border.transform.localPosition = new Vector3(-954.02002f, -542.51001f, 1.13440001f);
            currentCamName = "Intersection";
            HideAllRooms();
            intersection.gameObject.SetActive(true);
        }
        else if (count == 2)
        {
            border.transform.localPosition = new Vector3(-955.059998f, -542.51001f, 1.13440001f);
            currentCamName = "West Hall";
            HideAllRooms();
            leftHall.gameObject.SetActive(true);
        }
        else if (count == 3)
        {
            border.transform.localPosition = new Vector3(-954.02002f, -541.789978f, 1.13440001f);
            currentCamName = "North Hall";
            HideAllRooms();
            topHall.gameObject.SetActive(true);
        }
        else if (count == 4)
        {
            border.transform.localPosition = new Vector3(-952.969971f, -542.51001f, 1.13440001f);
            currentCamName = "East Hall";
            HideAllRooms();
            rightHall.gameObject.SetActive(true);
        }
        count += 1;
    }
}
