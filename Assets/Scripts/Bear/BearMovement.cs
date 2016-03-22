using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BearMovement : MonoBehaviour
{
    public float speed = 1.0F;
    public float jumpSpeed = 8.0F;
    private Vector2 moveDirection = Vector2.left;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Rigidbody2D body = GetComponent<Rigidbody2D>();

	    moveDirection = defineMoveDirection(moveDirection);
        //moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        body.velocity = new Vector2(moveDirection.x,body.velocity.y);
 

    }

    private Vector2 defineMoveDirection(Vector2 moveDirection)
    {
        int chance = 10;
        Vector2 vecteur = new Vector2(moveDirection.x,moveDirection.y);

        if (Random.Range(1, 100) <= chance)
        {
            vecteur.x *= -1;
        }
        

        return vecteur;
    }
}