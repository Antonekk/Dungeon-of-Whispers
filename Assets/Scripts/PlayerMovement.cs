using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private EntityMovement playerMovement;
    private PlayerController playerController;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerMovement = GetComponent<EntityMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        playerMovement.EntityMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),playerController.movement_speed);

        playerMovement.EntityRotation(Input.mousePosition);

    }



    public void Teleport(Vector3 pos)
    {
        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
    }
}
