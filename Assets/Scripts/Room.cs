using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public Transform middle;

    public bool is_empty;

    public bool is_starting_point;
    public bool is_endpoint;


    public bool has_exit_top;
    public bool has_exit_bottom;
    public bool has_exit_left;
    public bool has_exit_right;

    public GameObject exit_top;
    public GameObject exit_bottom;
    public GameObject exit_left;
    public GameObject exit_right;

    public GameObject room_top;
    public GameObject room_bottom;
    public GameObject room_left;
    public GameObject room_right;



    public GameObject doorpref;
    public GameObject wallpref;

    public GameObject exit_door;

    private void Awake()
    {
        exit_door = transform.Find("Exit").gameObject;
    }

    void Start()
    {
        is_empty = true;
        if (is_starting_point)
        {
            UpdateDoors();
            is_empty = true;
        }
    }


    public void UpdateDoors()
    {
        exit_top = GenerateRoomExitsForPoint(has_exit_top, exit_top, room_top);
        exit_bottom = GenerateRoomExitsForPoint(has_exit_bottom, exit_bottom, room_bottom);
        exit_left = GenerateRoomExitsForPoint(has_exit_left, exit_left, room_left);
        exit_right = GenerateRoomExitsForPoint(has_exit_right, exit_right, room_right);
        if (is_endpoint)
        {
            Debug.Log("Noo");
            exit_door.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    GameObject GenerateRoomExitsForPoint(bool has_exit, GameObject point, GameObject exit_door_room)
    {
        GameObject obj;
        if (has_exit)
        {
            obj = Instantiate(doorpref, point.transform.position, point.transform.rotation, transform);
            obj.GetComponent<DoorLogic>().exit_room = exit_door_room;
        }
        else
        {
            obj = Instantiate(wallpref, point.transform.position, point.transform.rotation, transform);
        }
        string old_point_name = point.name;
        obj.name = old_point_name;
        Destroy(point);
        return obj ;


    }
}