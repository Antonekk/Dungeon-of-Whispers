using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    public int max_hp;
    public float current_hp;
    public float atack_speed;
    public float movement_speed;
    public float basic_atack_damage;

    public bool is_alive;
    public bool can_atack;


    virtual protected void Awake()
    {
        can_atack = true;
        is_alive = true;
    }

    public void Heal(float hp)
    {
        current_hp = Mathf.Min(current_hp + hp, max_hp);
    }
    public virtual void Hurt(float damage)
    {
        if(current_hp - damage <= 0)
        {
            ActionOnDeath();
        }
        else
        {
            current_hp -= damage;
        }
    }


     protected virtual void ActionOnDeath()
    {
        current_hp = 0;
        is_alive = false;
        Destroy(gameObject);
    }


    protected IEnumerator BasicAtackCooldown()
    {
        can_atack = false;
        yield return new WaitForSeconds(atack_speed);
        can_atack = true;
    }

}
