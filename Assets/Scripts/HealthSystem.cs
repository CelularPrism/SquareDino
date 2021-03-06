using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private Image imageHealth;
    public bool isLive = true; 

    public void Damage(int damage)
    {
        Health -= damage;
        imageHealth.fillAmount = (float)Health / (float)maxHealth;

        if (Health <= 0)
        {
            if (transform.GetComponent<Enemy>() != null)
                transform.GetComponent<Enemy>().enabled = false;
            imageHealth.gameObject.SetActive(false);
            isLive = false;
        }
    }
}
