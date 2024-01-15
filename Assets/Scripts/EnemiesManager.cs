using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    Transform floor;
    List<Transform> floor_tiles;
    GameManager game_manager;
    public int start_enemies_cout;

    public List<GameObject> enemies;
    public Transform enemies_list_object;

    public GameObject room_enemy;
    Vector3 enemy_up_offset = new(0, 1f, 0);

    void Start()
    {
        if (!GetComponent<Room>().is_starting_point)
        {
            floor = gameObject.transform.Find("Floor");
            enemies_list_object = gameObject.transform.Find("Enemies");
            floor_tiles = ArrayFunctions.GetChildrenList(floor);
            game_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            start_enemies_cout = Randomizer.RandomEnemies(game_manager.min_enemies_per_room, game_manager.max_enemies_per_room);
            GenerateEnemies();
        }
        

    }


    void GenerateEnemies()
    {
        for(int i = 0; i< start_enemies_cout; i++) {
            Transform enemy_pos = Randomizer.GetRandomElement(floor_tiles);
            GameObject new_enemy = Instantiate(room_enemy, enemy_pos.position + enemy_up_offset, new Quaternion(0, 0, 0, 1), enemies_list_object);
            enemies.Add(new_enemy);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
