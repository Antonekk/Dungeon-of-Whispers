using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{

    public Transform current_target;
    List<Transform> floor_tiles;
    EnemyMovement movement_script;
    GameManager gm;
    private EnemyController enemy_controller;


    void Start()
    {
        enemy_controller = gameObject.GetComponent<EnemyController>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        floor_tiles = ArrayFunctions.GetChildrenList(transform.parent.parent.Find("Floor"));
        movement_script = GetComponent<EnemyMovement>();
        FindNextTarget();

    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, current_target.position) < 1.1f)
        {
            
            FindNextTarget();
        }

        Vector3 direction = current_target.position - transform.position;

        movement_script.EnemyMove(direction,enemy_controller.movement_speed);

    }

    void FindNextTarget()
    {
        current_target = Randomizer.GetRandomElement(floor_tiles);
    }




}
