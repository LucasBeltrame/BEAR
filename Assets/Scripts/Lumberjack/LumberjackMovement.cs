using UnityEngine;
using System.Collections;

public class LumberjackMovement : MonoBehaviour {

    public float speed = 5.0F;
    public float jumpSpeed = 8.0F;
	public GameObject background;

    private Rigidbody2D body;
    private float movex = 0f;
    public  bool moveBackground = true;

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
	    if (moveBackground)
	    {
            background.GetComponent<FreeParallax>().Speed = movex * -1.0f;
        }
        else
        {
            background.GetComponent<FreeParallax>().Speed =0.0f;
        }

        if(movex > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(movex < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
