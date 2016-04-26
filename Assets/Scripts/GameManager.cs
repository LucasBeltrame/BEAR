using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public int playerRessourcesPoints = 0;
	public BoardManager boardScript;

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
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	public void GameOver()
	{
		enabled = false;
	}
}
