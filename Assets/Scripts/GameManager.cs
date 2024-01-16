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

        CorrectEnemies();


    }

    private static void CorrectEnemies()
    {
        GMInstance.min_enemies_per_room = GMInstance.game_level;
        GMInstance.max_enemies_per_room = 2 * GMInstance.game_level;
    }
    public static void UpdateLevel()
    {
        CorrectEnemies();
        GMInstance.game_level += 1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
