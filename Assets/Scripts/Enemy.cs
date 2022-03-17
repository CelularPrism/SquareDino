using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private Movement movement;
    private HealthSystem healthSystemPlayer;
    private int damage;
    private float timeNextAttack;
    private float timeReloadAttack;
    
    void Start()
    {
        healthSystemPlayer = player.GetComponent<HealthSystem>();
        movement = transform.GetComponent<Movement>();
        damage = 3;
        timeReloadAttack = 2f;
        timeNextAttack = Time.time - timeReloadAttack;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 0.9f)
        {
            transform.LookAt(player.position);
            movement.SetPoint(player.position, speed);
        } else if (timeNextAttack < Time.time)
        {
            healthSystemPlayer.Damage(damage);
            timeNextAttack = Time.time + timeReloadAttack;
        }

        if (!transform.GetComponent<HealthSystem>().isLive)
            Destroy(transform.gameObject);
    }
}
