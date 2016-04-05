using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public int health = 10;
    public Text healthText;

    public void Damage(int damageCount)
    {
        health -= damageCount;
        Debug.Log("stuff happened" + gameObject);

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        healthText.text = "Sanders: " + health.ToString();
    }
}
