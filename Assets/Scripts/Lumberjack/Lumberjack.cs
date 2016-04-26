using UnityEngine;
using System.Collections;

public class Lumberjack : MonoBehaviour {

	public float moveTime = 0.5f;
	public LayerMask blockingLayer;
	// Temporaire
	public int pointsPerLogs = 20;
	public int pointsPerFuel = 5;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;

	private Animator animator;
	private int ressources;

	// Use this for initialization
	void Start ()
	{
		boxCollider = GetComponent<BoxCollider2D> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
