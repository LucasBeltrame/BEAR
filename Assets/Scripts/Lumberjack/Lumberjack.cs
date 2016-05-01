using System;
using UnityEngine;
using System.Collections;

public class Lumberjack : MonoBehaviour {

	public float moveTime = 0.5f;
	public LayerMask blockingLayer;

    public bool isVisible = true;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;

	private Animator animator;
	private int ressources;

	// Use this for initialization
	void Start ()
	{
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / moveTime;

		animator = GetComponent<Animator> ();
		//ressources = GameManager.instance.playerRessourcesPoints;
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rock")
            this.GetComponent<LumberjackMovement>().moveBackground = false;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rock")
            this.GetComponent<LumberjackMovement>().moveBackground = true;
    }

    public void changeVisibleStatus()
    {
        isVisible = !isVisible;
    }
}
