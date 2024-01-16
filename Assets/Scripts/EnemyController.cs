using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyController : EntityBase
{

    public Room enemy_room;
    public UnityEvent check_for_empty_room = new();
    public float dashspeed;

    void Start()
    {
        enemy_room = transform.parent.parent.GetComponent<Room>();
        check_for_empty_room.AddListener(enemy_room.CheckForEmpytyRoom);
        max_hp = 5;
        current_hp = max_hp;
        atack_speed = 0.25f;
        movement_speed = 5f;
        basic_atack_damage = 0.25f;
        dashspeed = 10f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (can_atack && other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Hurt(basic_atack_damage);
            StartCoroutine(BasicAtackCooldown());

        }
    }

    private void OnDestroy()
    {
        check_for_empty_room.Invoke();
    }


}
