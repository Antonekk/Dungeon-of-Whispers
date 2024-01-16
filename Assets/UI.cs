using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI UIInstance;

    void Awake()
    {

        if (UIInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        UIInstance = this;
        DontDestroyOnLoad(gameObject);



    }
}
