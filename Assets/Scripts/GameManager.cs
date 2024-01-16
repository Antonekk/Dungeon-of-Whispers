using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int game_level;
    public int min_enemies_per_room;
    public int max_enemies_per_room;
    public GameObject player;

    public static GameManager GMInstance;


    void Awake()
    {


        if (GMInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        GMInstance = this;
        DontDestroyOnLoad(gameObject);

        min_enemies_per_room = game_level;
        max_enemies_per_room = 2 * game_level;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
