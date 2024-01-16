using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using System;


public class RoomGenerator : MonoBehaviour
{
    private const  int TOP = 1; //Nazwa dla górnych drzwi
    private const int BOT = 2; //Nazwa dla dolnych drzwi
    private const int LFT = 3; //Nazwa dla lewych drzwi
    private const int RGT = 4; //Nazwa dla prawych drzwi
    public List<int> doors;
    public GameObject[,] rooms_layout;

    private Vector3 horizontal_offset = new(30.0f, 0, 0);
    private Vector3 vertical_offset = new(0.0f, 0, 17.7f);


    public int room_count;
    public int level_rank;
    public GameObject spawn;
    public GameObject roompref;

    public List<GameObject> rooms = new();

    public Transform rooms_storage;
    void Start()
    {
        room_count = (2 * level_rank) + 1;
        doors = new List<int>() { 1, 2, 3, 4 };
        rooms_layout = new GameObject[(room_count*2)+3, (room_count * 2) + 3];
        //wyliczamy œrodkowy index dla startowego pola
        int spawn_room_index = ((room_count * 2) + 3) / 2;


        spawn = Instantiate(roompref, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1), rooms_storage);
        spawn.GetComponent<Room>().is_starting_point = true; //Change
        rooms.Add(spawn);
        rooms_layout[spawn_room_index, spawn_room_index] = spawn;
        for (int i = 1; i < room_count; i++)
        {
            AddRoom();
        }
        SetupExit();

    }


    void SetupExit()
    {
        Room room_com = rooms[rooms.Count - 1].GetComponent<Room>();
        room_com.is_endpoint = true;
        room_com.UpdateDoors();
    }

    void AddRoom()
    {
        GameObject next_to = Randomizer.GetRandomElement<GameObject>(rooms);
        List<int> doors_check_order = Randomizer.GetRandomPermutation<int>(doors);
        foreach (int door in doors_check_order)
        {
            var new_room = InstantiateRoomNextTo(next_to, door);
            if (new_room != null ? new_room.gameObject : null)
            {
                new_room.GetComponent<Room>().UpdateDoors();
                next_to.GetComponent<Room>().UpdateDoors();
                rooms.Add(new_room);
                break;
            }


        }
    }

    GameObject InstantiateRoomNextTo(GameObject room, int side)
    {
        Transform room_transform = room.transform;
        Tuple<int, int> room_coords = ArrayFunctions.CoordinatesOf(rooms_layout, room);
        switch (side)
        {
            case TOP:
                if (!room.GetComponent<Room>().has_exit_top && rooms_layout[room_coords.Item1+1,room_coords.Item2] is null)
                {
                    GameObject new_room = Instantiate(roompref, room_transform.position + vertical_offset, new Quaternion(0, 0, 0, 1), rooms_storage);
                    room.GetComponent<Room>().has_exit_top = true;
                    room.GetComponent<Room>().room_top = new_room;
                    new_room.GetComponent<Room>().has_exit_bottom = true;
                    new_room.GetComponent<Room>().room_bottom = room;
                    rooms_layout[room_coords.Item1 + 1, room_coords.Item2] = new_room;
                    return new_room;
                }
                return null;
            case BOT:
                if (!room.GetComponent<Room>().has_exit_bottom && rooms_layout[room_coords.Item1 - 1, room_coords.Item2] is null)
                {
                    GameObject new_room = Instantiate(roompref, room_transform.position - vertical_offset, new Quaternion(0, 0, 0, 1), rooms_storage);
                    room.GetComponent<Room>().has_exit_bottom = true;
                    room.GetComponent<Room>().room_bottom = new_room;
                    new_room.GetComponent<Room>().has_exit_top = true;
                    new_room.GetComponent<Room>().room_top = room;
                    rooms_layout[room_coords.Item1 -1 , room_coords.Item2] = new_room;
                    return new_room;
                }
                return null;
            case LFT:
                if (!room.GetComponent<Room>().has_exit_left && rooms_layout[room_coords.Item1, room_coords.Item2 - 1] is null)
                {
                    GameObject new_room = Instantiate(roompref, room_transform.position - horizontal_offset, new Quaternion(0, 0, 0, 1), rooms_storage);
                    room.GetComponent<Room>().has_exit_left = true;
                    room.GetComponent<Room>().room_left = new_room;
                    new_room.GetComponent<Room>().has_exit_right = true;
                    new_room.GetComponent<Room>().room_right = room;
                    rooms_layout[room_coords.Item1, room_coords.Item2 - 1] = new_room;
                    return new_room;
                }
                return null;
            case RGT:
                if (!room.GetComponent<Room>().has_exit_right && rooms_layout[room_coords.Item1, room_coords.Item2 + 1] is null)
                {
                    GameObject new_room = Instantiate(roompref, room_transform.position + horizontal_offset, new Quaternion(0, 0, 0, 1), rooms_storage);
                    room.GetComponent<Room>().has_exit_right = true;
                    room.GetComponent<Room>().room_right = new_room;
                    new_room.GetComponent<Room>().has_exit_left = true;
                    new_room.GetComponent<Room>().room_left = room;
                    rooms_layout[room_coords.Item1, room_coords.Item2 + 1] = new_room;
                    return new_room;
                }
                return null;
            default:
                return null;

        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    

}
