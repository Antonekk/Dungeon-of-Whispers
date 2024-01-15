using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New spell", menuName = "Spell")]
public class Spell : ScriptableObject
{
    public float damage;
    public float speed;
    public string spell_name;
}
