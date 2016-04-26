using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehavior : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonStartClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonQuitClick()
    {
        Application.Quit();
    }
}
