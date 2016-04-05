using UnityEngine;
using System.Collections;

public class LumberjackMovement : MonoBehaviour {

    public float speed = 5.0F;
    public float jumpSpeed = 8.0F;
    private Rigidbody2D body;

    private float movex = 0f;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        movex = Input.GetAxis("Horizontal");

        movex *= speed;
        body.velocity = new Vector2(movex, body.velocity.y);
    }
}
