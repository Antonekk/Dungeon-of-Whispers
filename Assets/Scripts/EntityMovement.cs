using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(rotate_point.x, rotate_point.y, 10f));

        // Calculate the direction from the character to the mouse position
        Vector3 direction = mouseWorldPosition - transform.position;

        // Calculate the rotation angle only on the Y-axis
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Rotate the character towards the mouse position (only on Y-axis)
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
