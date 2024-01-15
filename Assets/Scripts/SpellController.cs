using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public Spell spell;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spell.speed > 0)
        {
            transform.Translate(Vector3.forward * spell.speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().Hurt(spell.damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
