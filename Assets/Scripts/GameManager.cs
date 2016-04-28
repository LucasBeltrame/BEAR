using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int playerRessourcesPoints = 0;
	public BoardManager boardScript;
    public GameObject GameOverCanvas;
    public Text deathText;
    private bool isGameOver = false;
    private Color color;

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

		DontDestroyOnLoad (gameObject);
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

            if (color.a >= 1.0f)
            {
                isGameOver = false;
                SceneManager.LoadScene("MainMenu");
            }
        }

    }
}
