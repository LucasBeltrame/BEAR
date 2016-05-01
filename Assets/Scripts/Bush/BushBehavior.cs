using UnityEngine;
using System.Collections;

public class BushBehavior : MonoBehaviour
{
    private bool playerIsHere = false;
    private GameObject player;
	
	void Update ()
    {
	    if(playerIsHere)
        {
            if(Input.GetKeyDown("up"))
            {
                player.GetComponent<SpriteRenderer>().sortingOrder = 8;
                player.GetComponent<Lumberjack>().isVisible = false;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GameManager.instance.bear.GetComponent<Collider2D>(), true);
}
            
            if(Input.GetKeyUp("up"))
            {
                player.GetComponent<SpriteRenderer>().sortingOrder = 10;
                player.GetComponent<Lumberjack>().isVisible = true;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GameManager.instance.bear.GetComponent<Collider2D>(), false);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsHere = true;
            player = other.gameObject;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsHere = false;

            player.GetComponent<SpriteRenderer>().sortingOrder = 10;
            player.GetComponent<Lumberjack>().isVisible = true;
        }
    }
}
