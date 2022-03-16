using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    private HealthSystem healthSystemPlayer;
    private int damage;
    private float timeNextAttack;
    private float timeReloadAttack;
    
    void Start()
    {
        healthSystemPlayer = player.GetComponent<HealthSystem>();
        damage = 3;
        timeReloadAttack = 2f;
        timeNextAttack = Time.time - timeReloadAttack;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 0.9f)
        {
            transform.LookAt(player.position);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (timeNextAttack < Time.time)
        {
            healthSystemPlayer.Damage(damage);
            timeNextAttack = Time.time + timeReloadAttack;
        }

        if (!transform.GetComponent<HealthSystem>().isLive)
            Destroy(transform.gameObject);
    }
}
