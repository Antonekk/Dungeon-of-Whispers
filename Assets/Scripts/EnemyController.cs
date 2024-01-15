using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : EntityBase
{
    void Start()
    {
        max_hp = 5;
        current_hp = max_hp;
        atack_speed = 0.25f;
        movement_speed = 5f;
        basic_atack_damage = 0.25f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (can_atack && other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            other.GetComponent<PlayerController>().Hurt(basic_atack_damage);
            StartCoroutine(BasicAtackCooldown());

        }
    }
}
