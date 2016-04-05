using UnityEngine;
using System.Collections;

public class SandersPlayerAttack : MonoBehaviour {
    private bool attacking = false;
    private float attackTimer = 0;
    public float attackCooldown = 0.3f;
    private float fireTimer = 0;
    public float fireCooldown = 5f;
    private bool fire = false;
    private float birdTimer = 0;
    public float birdCooldown = 7f;
    private bool bird = false;
    Animator anim;

    private bool classified = false;
    private float classifiedTimer = 0;
    public float classifiedCooldown = 0.8f;

    public Collider2D attackTrigger;

    void Awake()
    {
        attackTrigger.enabled = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown("w") && !attacking && !classified)
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

        if (Input.GetKeyDown("z") && !fire && !classified)
        {
            anim.SetBool("Fire", true);
            fire = true;
            fireTimer = fireCooldown;
            transform.GetChild(0).gameObject.GetComponent<AttackTriggerScript>().damage = 4;
        }

        if (fire)
        {
            if (fireTimer > 0)
            {
                fireTimer -= Time.deltaTime;
            }
            else
            {
                anim.SetBool("Fire", false);
                fire = false;
                transform.GetChild(0).gameObject.GetComponent<AttackTriggerScript>().damage = 2;
            }
        }

        if (Input.GetKeyDown("x") && !bird && !fire && !classified)
        {
            anim.SetBool("Bird", true);
            bird = true;
            birdTimer = birdCooldown;
        }

        if (bird)
        {
            if (birdTimer > 0)
            {
                birdTimer -= Time.deltaTime;
            }
            else
            {
                anim.SetBool("Bird", false);
                bird = false;
                GetComponent<HealthScript>().health += 2;
            }
        }

        if (classified)
        {
            if (classifiedTimer > 0)
            {
                classifiedTimer -= Time.deltaTime;
            }
            else
            {
                anim.SetBool("Classified", false);
                classified = false;
            }
        }
    }

    public void Email()
    {
        if (!bird && !fire)
        {
            classified = true;
            anim.SetBool("Classified", true);
            classifiedTimer = classifiedCooldown;
        }
    }
}
