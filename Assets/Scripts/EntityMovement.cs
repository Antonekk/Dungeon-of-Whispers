using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EntityMovement : MonoBehaviour
{
    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void EntityMove(float x_axis, float z_axis, float speed)
    {
        Vector3 move = new Vector3(x_axis, 0.0f, z_axis).normalized;

        if (move.magnitude >= 0.1f)
        {
            // Move the enemy towards the player
            transform.Translate(move * speed * Time.deltaTime, Space.World);
        }

    }

    public void EntityRotation(Vector3 rotate_point)
    {
        Vector3 worldPosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
            worldPosition.y = 0f; // Ensure the z-coordinate is in the same plane as the player

            // Calculate the direction from the player to the mouse
            Vector3 lookDirection = worldPosition - transform.position;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;

            // Rotate the player around the Z-axis
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

        }

        


    }
}
