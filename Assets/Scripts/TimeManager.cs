using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float nbMinutesPerDay = 5.0f;
    public Text dayText;
    public Text timeText;
    public Text AnnonceJourText;
    public Canvas annonceCanvas;

    private bool countTime = false;
    private float timeElapsed = 0.0f;
    private const float SEC_PER_MIN = 60.0f;
    private int noDay;
    private float actualTime = 12.0f;
    private float hoursPassed = 0.0f;
    private float hourPerDay = 7.0f;
    private  CanvasGroup annonceCanvasGroup;
    // Use this for initialization
    void Start ()
	{
	    timeElapsed = 0.0f;
	    noDay = 1;
        annonceCanvasGroup = annonceCanvas.GetComponent<CanvasGroup>();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    ManageTime();
	}

    void ManageTime()
    {
        if (timeElapsed == 0.0f)
        {
            dayText.text = "Jour : " + noDay.ToString();
            AnnonceJourText.text = "Jour " + noDay.ToString();
        }

        if (countTime == true)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            annonceCanvasGroup.alpha -= 0.008f;
            if (annonceCanvasGroup.alpha <= 0)
            {
                countTime = true;
                annonceCanvasGroup.alpha = 0.0f;
            }
        }

        if (timeElapsed >= nbMinutesPerDay * SEC_PER_MIN)
        {
            noDay++;
            timeElapsed = 0.0f;
            hoursPassed = 0.0f;
            countTime = false;
            annonceCanvasGroup.alpha = 1.0f;
        }

        timeText.text = GetActualTimeString();
    }

    string GetActualTimeString()
    {
        actualTime = 12.0f;

        float increment = timeElapsed * (hourPerDay - nbMinutesPerDay) / (nbMinutesPerDay * SEC_PER_MIN);
        actualTime += increment;

        TimeSpan timeSpan = TimeSpan.FromHours(actualTime * nbMinutesPerDay);
        string resultText = string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes);

        return resultText;
    }
}
