using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private Room parent_room;

    private void Start()
    {
        parent_room = transform.parent.GetComponent<Room>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && parent_room.is_empty)
        {
            GameManager.UpdateLevel();
            Debug.Log(GameManager.GMInstance.game_level);
            SceneManager.LoadScene(0);
        }
    }
}
