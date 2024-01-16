using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void ResetGame()
    {
        Destroy(GameManager.GMInstance.gameObject);
        Destroy(UI.UIInstance.gameObject);
        SceneManager.LoadScene(0);
    }
}
