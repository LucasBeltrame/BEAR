using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            GameManager.instance.GameOver();
    }
}
