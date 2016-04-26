using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{
	public float moveTime = 0.5f;
	public LayerMask blockingLayer;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;


	// Use this for initialization
	protected virtual void Start ()
	{
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

