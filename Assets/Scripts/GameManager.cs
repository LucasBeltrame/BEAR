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
    public Text deathText;
    public Text ScoreText;
    public int nbDay = 1;

    private bool isGameOver = false;
    private Color color;
    private float waitTime = 3.0f;
    private float elapsedTime = 0;
    private bool waitBeforeLoadMenu = false;

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

        //pas besoin
		//DontDestroyOnLoad (gameObject);
		//boardScript = GetComponent<BoardManager> ();
		//InitGame ();
	}

	public void GameOver()
	{
        GameOverCanvas.SetActive(true);
	    isGameOver = true;
	    color = deathText.color;
	}

    void Update()
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
                Debug.Log(elapsedTime);
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= waitTime)
                {
                    waitBeforeLoadMenu = false;
                    isGameOver = false;
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }
}
