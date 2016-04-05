using UnityEngine;
using System.Collections;

public class TrumpMoveScript : MonoBehaviour {

    public Vector2 speed = new Vector2(7, 50);
    private Vector2 movement;
    bool facingRight = true;
    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("TrumpHorizontal");

        movement = new Vector2(speed.x * inputX, 0);
        if (inputX > 0)
        {
            anim.SetBool("Moving", true);
            if (!facingRight)
            {
                Flip();
            }
        }
        else if (inputX < 0)
        {
            anim.SetBool("Moving", true);
            if (facingRight)
            {
                Flip();
            }
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
        if (Input.GetKeyDown("8")) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
