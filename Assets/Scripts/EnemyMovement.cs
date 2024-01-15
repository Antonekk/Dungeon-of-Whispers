using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public void EnemyMove(Vector3 direction, float speed)
    {
        direction.y = 0; // Exclude the Y-component for movement in XZ-plane

        // Normalize the direction to get a unit vector
        direction.Normalize();

        // Move the enemy towards the player
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Rotate the enemy to face the player
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10f);
        }

    }


    public void EnemyRotation(Vector3 rotate_point)
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
