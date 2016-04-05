using UnityEngine;
using System.Collections;

public class ClintonPlayerAttack : MonoBehaviour {
    private bool attacking = false;
    private float attackTimer = 0;
    public float attackCooldown = 0.3f;
    public Collider2D attackTrigger;

    private bool emailing = false;
    private float emailTimer = 0;
    public float emailCooldown = 0.5f;
    public Collider2D emailTrigger;
    Animator anim;

    void Awake()
    {
        attackTrigger.enabled = false;
        emailTrigger.enabled = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown("down") && !attacking)
        {
            anim.SetBool("Punching", true);
            attacking = true;
            attackTrigger.enabled = true;
            attackTimer = attackCooldown;
        }

        if (attacking)
        {
            if(attackTimer>0)
            {
                attackTimer -= Time.deltaTime;
            } else
            {
                anim.SetBool("Punching", false);
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        if (Input.GetKeyDown("m") && !emailing)
        {
            emailing = true;
            emailTrigger.enabled = true;
            emailTimer = emailCooldown;
        }

        if (emailing)
        {
            if (emailTimer > 0)
            {
                emailTimer -= Time.deltaTime;
            }
            else
            {
                emailing = false;
                emailTrigger.enabled = false;
            }
        }
    }
}
