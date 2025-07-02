using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatController : MonoBehaviour
{
    public  int shotsHit = 0;
    public  int shotsFired = 0;
    public float time = 0;
    public bool timeTick;
    public TextMeshProUGUI shotsHitDisplay;
    public TextMeshProUGUI shotsFiredDisplay;
    public TextMeshProUGUI timeTakenDisplay;
    public SimpleShoot simpleShoot;
    

    // Start is called before the first frame update
    void Start()
    {
        timeTick = true;
    }

    // Update is called once per frame
    void Update()
    {
        shotsHitDisplay.text = "Shots hit =" + shotsHit;
        shotsFiredDisplay.text = "Shots fired =" + shotsFired;
        
        if (shotsHit == 12)
        {
            timeTick = false;
        }

        if (timeTick)
        {
            time += Time.deltaTime;
        }
        else 
        {

        }

        timeTakenDisplay.text = "Time Taken =" + time;


    }
}
