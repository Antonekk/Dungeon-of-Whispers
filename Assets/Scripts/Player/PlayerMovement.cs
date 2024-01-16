using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private EntityMovement playerMovement;
    private PlayerController playerController;

    private bool is_dashing;
    private float dash_cooldown;


    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerMovement = GetComponent<EntityMovement>();
        dash_cooldown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        playerMovement.EntityMove(hori, vert,playerController.movement_speed);

        playerMovement.EntityRotation(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space) && !is_dashing)
        {
            StartCoroutine(Dash(hori,vert));
        }

    }



    IEnumerator Dash(float hori, float vert)
    {
        // Start dashing

        // Apply dash force in the direction of the player's current speed
        Vector2 dashDirection = GetComponent<Rigidbody>().velocity.normalized;
        GetComponent<Rigidbody>().velocity = dashDirection * playerController.dash_speed;

        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 move_dir = new Vector3(hori,0f,vert).normalized;
        rb.velocity =  new Vector3(playerController.dash_speed*move_dir.x,rb.velocity.y*move_dir.y, playerController.dash_speed*move_dir.z);  
        is_dashing = true;
        yield return new WaitForSeconds(dash_cooldown);
        is_dashing = false;
    }



    public void Teleport(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
    }
}
