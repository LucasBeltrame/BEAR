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
    public GameObject background;

    private Animator animator;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        animator.SetBool("isWalking",true);
        animator.SetInteger("Direction",direction);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    timer += Time.deltaTime;
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        //Movement
	    defineMoveDirection();

        body.velocity = new Vector2(moveDirection.x,body.velocity.y);

        //Bakground movement
        background.GetComponent<FreeParallax>().Speed = moveDirection.x * -1.0f;


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
}