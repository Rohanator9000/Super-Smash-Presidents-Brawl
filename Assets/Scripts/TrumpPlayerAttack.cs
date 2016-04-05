using UnityEngine;
using System.Collections;

public class TrumpPlayerAttack : MonoBehaviour {
    private bool attacking = false;
    private float attackTimer = 0;
    public float attackCooldown = 0.3f;
    public Collider2D attackTrigger;
    Animator anim;
    public Rigidbody2D wallPrefab;

    private bool classified = false;
    private float classifiedTimer = 0;
    public float classifiedCooldown = 0.8f;

    void Awake()
    {
        attackTrigger.enabled = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown("0") && !attacking && !classified)
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

        if(Input.GetKeyDown("9") && !classified)
        {
            Rigidbody2D wallInstance;
            wallInstance = Instantiate(wallPrefab, transform.position, transform.rotation) as Rigidbody2D;
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
        classified = true;
        anim.SetBool("Classified", true);
        classifiedTimer = classifiedCooldown;
    }
}
