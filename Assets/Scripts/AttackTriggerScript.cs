using UnityEngine;
using System.Collections;

public class AttackTriggerScript : MonoBehaviour {
    public int damage = 2;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.isTrigger)
        {
            col.SendMessageUpwards("Damage", damage);
            Debug.Log("message was sent");
        }
    }
}
