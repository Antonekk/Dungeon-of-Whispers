using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityBase
{

    HealthBarController HBC;
    Animator playeranimator;
    public GameObject basic_atack_projectile;
    private Transform cast_point;

    public static PlayerController PlayerInstance;
    Vector3 player_starting_position = new(-0.416496277f, 1.57000005f, 6.27987576f);
    Vector3 player_starting_rotation = new(9.33466799e-06f, 0f, 0f);




    protected override void Awake()
    {

        if (PlayerInstance != null)
        {
            PlayerInstance.transform.position = player_starting_position;
            Destroy(gameObject);
            return;
        }
        // end of new code

        PlayerInstance = this;
        DontDestroyOnLoad(gameObject);

        can_atack = true;
        is_alive = true;

    }

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
