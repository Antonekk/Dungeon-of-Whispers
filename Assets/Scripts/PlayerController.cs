using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityBase
{

    HealthBarController HBC;
    Animator playeranimator;
    public GameObject basic_atack_projectile;
    private Transform cast_point;


    void Start()
    {
        cast_point = transform.Find("SpellsSpawnPoint");
        playeranimator = GetComponent<Animator>();
        HBC = GameObject.Find("HealthBarController").GetComponent<HealthBarController>();
        max_hp = 3;
        current_hp = max_hp;
        atack_speed = 0.5f;
        movement_speed = 5f;
        basic_atack_damage = 1;
    }


    void CastBasicAtack()
    {
        playeranimator.Play("PlayerCastAnimation");
        StartCoroutine(BasicAtackCooldown());
        Instantiate(basic_atack_projectile, cast_point.position, cast_point.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        HBC.UpdateHeartsHUD();
        if (Input.GetMouseButton(0) && can_atack)
        {
            CastBasicAtack();
        }
    }


}
