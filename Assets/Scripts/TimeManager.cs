using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    public float nbMinutesPerDay = 3.0f;
    private float timeElapsed = 0.0f;
    private const float SEC_PER_MIN = 60.0f;
    private int noDay;
	// Use this for initialization
	void Start ()
	{
	    timeElapsed = 0.0f;
	    noDay = 1;

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
            print("Day " + noDay + " begin ! ");
        }

        timeElapsed += Time.deltaTime;

        if (timeElapsed >= nbMinutesPerDay * SEC_PER_MIN)
        {
            print("Day " + noDay + " Ended ! ");
            noDay++;
            timeElapsed = 0.0f;
        }
    }
}
