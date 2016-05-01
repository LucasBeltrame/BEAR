using System;
using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int playerRessourcesPoints = 0;
	public BoardManager boardScript;
    public GameObject GameOverCanvas;
    public GameObject HUD;
    public Text deathText;
    public Text ScoreText;
    public Text FoodText;
    public int nbDay = 1;
    public bool isGameOver = true;

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

        //DontDestroyOnLoad (gameObject);
        //DontDestroyOnLoad(HUD);
		//boardScript = GetComponent<BoardManager> ();
		//InitGame ();
	}

	public void GameOver()
	{
        GameOverCanvas.SetActive(true);
	    isGameOver = true;
	    color = deathText.color;
        HUD.SetActive(false);
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
