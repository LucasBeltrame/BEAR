﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int playerRessourcesPoints = 1;
	public BoardManager boardScript;
    public GameObject GameOverCanvas;
    public GameObject HUD;
    public Text deathText;
    public Text ScoreText;
    public Text FoodText;
    public int nbDay = 1;
    public bool isGameOver = true;
    public bool isNearHouse = false;
    public GameObject bear;

    public GameObject bearPrefab;

    public GameObject[] bearLocations;

    private Color color;
    private float waitTime = 3.0f;
    private float elapsedTime = 0;
    private bool waitBeforeLoadMenu = false;
    private bool doUpdates = false;

	void InitGame()
	{
		boardScript.SetupScene ();
	}

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
        HUD.SetActive(true);
        isGameOver = false;
        doUpdates = true;
        playerRessourcesPoints = 1;
	}

	public void GameOver()
	{
        GameOverCanvas.SetActive(true);
	    isGameOver = true;
	    color = deathText.color;
        HUD.SetActive(false);
    }

    public void BearSpawn()
    {
        if(nbDay >= 2)
        {
            Destroy(bear);
            int id = Random.Range(0, bearLocations.Length);
            bear = (GameObject)Instantiate(bearPrefab, bearLocations[id].transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        //Don't update if the level is not loaded
        if(doUpdates)
        {
            //GameOver
            if (isGameOver)
            {

                color.a += 0.009f;
                deathText.color = color;
                ScoreText.color = color;
                string strjour = (nbDay > 1) ? " jours" : " jour";
                ScoreText.text = "Vous avez survécu " + nbDay.ToString() + strjour;

                if (color.a >= 1.0f && waitBeforeLoadMenu == false)
                {
                    elapsedTime = 0;
                    waitBeforeLoadMenu = true;

                }
                if (waitBeforeLoadMenu)
                {
                    elapsedTime += Time.deltaTime;
                    if (elapsedTime >= waitTime)
                    {
                        waitBeforeLoadMenu = false;
                        doUpdates = false;
                        SceneManager.LoadScene("MainMenu");
                    }
                }
            }
            else
            {
                FoodText.text = "Nourriture : " + playerRessourcesPoints.ToString();
            }
        }
    }
}
