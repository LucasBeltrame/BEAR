using UnityEngine;
using System.Collections;

public class HouseEnterIndicator : MonoBehaviour
{
    public GameObject indicator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            indicator.SetActive(true);
            GameManager.instance.isNearHouse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            indicator.SetActive(false);
            GameManager.instance.isNearHouse = false;
        }
    }
}
