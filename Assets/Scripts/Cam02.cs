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
        
        if (count > 4)
        {
            count = 1;
        }
        if(count == 1)
        {
            border.transform.localPosition = new Vector2(646, -271);
            currentCamName = "Intersection";
            HideAllRooms();
            intersection.gameObject.SetActive(true);
        }
        else if (count == 2)
        {
            border.transform.localPosition = new Vector2(532, -271);
            currentCamName = "West Hallway";
            HideAllRooms();
            leftHall.gameObject.SetActive(true);
        }
        else if (count == 3)
        {
            border.transform.localPosition = new Vector2(646, -191);
            currentCamName = "North Hallway";
            HideAllRooms();
            topHall.gameObject.SetActive(true);
        }
        else if (count == 4)
        {
            border.transform.localPosition = new Vector2(759, -271);
            currentCamName = "East Hallway";
            HideAllRooms();
            rightHall.gameObject.SetActive(true);
        }
        count += 1;
    }
}
