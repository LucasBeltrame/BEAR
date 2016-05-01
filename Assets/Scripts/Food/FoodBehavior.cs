using UnityEngine;
using System.Collections;

public class FoodBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.playerRessourcesPoints++;
            gameObject.SetActive(false);
        }
            
    }
}
