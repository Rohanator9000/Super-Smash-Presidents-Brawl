using UnityEngine;
using System.Collections;

public class SandersMoveScript : MonoBehaviour {

    public Vector2 speed = new Vector2(7, 50);
    private Vector2 movement;
    bool facingRight = true;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("BernieHorizontal");
        movement = new Vector2(speed.x * inputX, 0);
        if (inputX > 0 && !facingRight)
        {
            Flip();
        } else if (inputX < 0 && facingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
        if (Input.GetKeyDown("space")) {
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
