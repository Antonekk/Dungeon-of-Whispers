using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI UIInstance;
    public GameObject button;
    public Animator animator;

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
        animator = GetComponent<Animator>();
        button = transform.Find("Button").gameObject;

    }


    public static void EndScreen()
    {
        UIInstance.button.SetActive(true);
        UIInstance.animator.Play("EndGame");

    }
}
