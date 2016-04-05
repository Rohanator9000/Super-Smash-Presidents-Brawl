using UnityEngine;
using System.Collections;

public class EmailTriggerScript : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.isTrigger)
        {
            col.SendMessageUpwards("Email");
        }
    }
}
