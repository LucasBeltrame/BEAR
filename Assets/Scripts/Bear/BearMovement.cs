using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BearMovement : MonoBehaviour
{
    public int direction = -1;
    public float speed = 1.0F;
    public float jumpSpeed = 8.0F;
    public float nbSecondBeforeDirectionChange = 1.0F;
    private Vector2 moveDirection = Vector2.left;
    private float timer = 0;

    private Vector2 playerPos = Vector2.zero;
    private bool isChasing = false;

    private Animator animator;

    // Use this for initialization
    void Start () {

        isChasing = false;
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking",true);
        animator.SetInteger("Direction",direction);
    }

	// Update is called once per frame
	void Update ()
	{
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        //Movement
	    if (isChasing)
	    {
	        chasePlayer();
	    }
	    else
	    {
           timer += Time.deltaTime;
	       defineMoveDirection();
	    }


        body.velocity = new Vector2(moveDirection.x,body.velocity.y);


    }

    private void chasePlayer()
    {
        float posX = this.GetComponent<Transform>().position.x;
        direction = ((playerPos.x - posX) > 0) ? 1 : -1;

        moveDirection.x = direction * speed;
    }

    private void defineMoveDirection()
    {
        int chance = 50;
        if (timer >= nbSecondBeforeDirectionChange)
        {
            timer = 0.0f;
            if (Random.Range(1, 100) <= chance)
            {
                direction *= -1;
                animator.SetInteger("Direction",direction);
            }
        }
        moveDirection.x = direction*speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isChasing = true;
            playerPos = other.gameObject.GetComponent<Transform>().position;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerPos = other.gameObject.GetComponent<Transform>().position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isChasing = false;
        }
    }
}
