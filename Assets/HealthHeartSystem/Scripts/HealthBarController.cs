/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;

    public Transform heartsParent;
    public GameObject heartContainerPrefab;

    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("GameManager").GetComponent<GameManager>().player.GetComponent<PlayerController>();
        heartContainers = new GameObject[player.max_hp];
        heartFills = new Image[player.max_hp];

        InstantiateHeartContainers();
        UpdateHeartsHUD();
    }

    public void UpdateHeartsHUD()
    {
        SetHeartContainers();
        SetFilledHearts();
    }

    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < player.max_hp)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }
    }

    void SetFilledHearts()
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            if (i < player.current_hp)
            {
                heartFills[i].fillAmount = 1;
            }
            else
            {
                heartFills[i].fillAmount = 0;
            }
        }

        if (player.current_hp % 1 != 0)
        {
            int lastPos = Mathf.FloorToInt(player.current_hp);
            heartFills[lastPos].fillAmount = player.current_hp % 1;
        }
    }

    void InstantiateHeartContainers()
    {
        for (int i = 0; i < player.max_hp; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent, false);
            heartContainers[i] = temp;
            heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
        }
    }
}
