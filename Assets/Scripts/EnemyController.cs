using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyController : EntityBase
{

    public Room enemy_room;
    public UnityEvent check_for_empty_room = new();
    public GameObject Drop;
    private float chance_to_drop;
    public GameObject particle_on_death;
    private AudioSource get_hit;

    void Start()
    {
        get_hit = GetComponent<AudioSource>();
        enemy_room = transform.parent.parent.GetComponent<Room>();
        check_for_empty_room.AddListener(enemy_room.CheckForEmpytyRoom);
        max_hp = 5;
        current_hp = max_hp;
        atack_speed = 0.25f;
        movement_speed = 8f;
        basic_atack_damage = 0.75f;
        chance_to_drop = 33f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (can_atack && other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Hurt(basic_atack_damage);
            StartCoroutine(BasicAtackCooldown());

        }
    }


    protected override void ActionOnDeath()
    {
        current_hp = 0;
        is_alive = false;
        if (Randomizer.RollD100(chance_to_drop))
        {
            Instantiate(Drop, transform.position, Quaternion.identity);
        }
        Instantiate(particle_on_death, transform.position + new Vector3(0,1.5f,0), Quaternion.identity);

        check_for_empty_room.Invoke();
        Destroy(gameObject);
    }


    public override void Hurt(float damage)
    {
        get_hit.Play();
        if (current_hp - damage <= 0)
        {
            ActionOnDeath();
        }
        else
        {
            current_hp -= damage;
        }
    }



}
