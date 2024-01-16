using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    Room parent_room_script;
    public GameObject exit_room;
    public GameObject main_camera;

    private Vector3 horizontal_offset = new(30.0f, 0, 0);
    private Vector3 vertical_offset = new(0.0f, 0, 17.7f);


    public Transform doors_open;
    public Transform doors_closed;

    void Awake()
    {
        main_camera = GameObject.Find("Main Camera");
        parent_room_script = GetComponentInParent<Room>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (parent_room_script.is_empty && other.CompareTag("Player"))
        {
            switch (gameObject.name)
            {
                case "ExitBot":
                    other.GetComponent<PlayerMovement>().Teleport(exit_room.GetComponent<Room>().exit_top.transform.position);
                    break;
                case "ExitTop":
                    other.GetComponent<PlayerMovement>().Teleport(exit_room.GetComponent<Room>().exit_bottom.transform.position);
                    break;
                case "ExitLeft":
                    other.GetComponent<PlayerMovement>().Teleport(exit_room.GetComponent<Room>().exit_right.transform.position);

                    break;
                case "ExitRight":
                    other.GetComponent<PlayerMovement>().Teleport(exit_room.GetComponent<Room>().exit_left.transform.position);

                    break;
                default:
                    break;
            }
            main_camera.GetComponent<CameraController>().SetCameraXZCoords(exit_room.GetComponent<Room>().middle.position);

        }
    }

    public void ChangeDoorColor()
    {
        doors_open.gameObject.SetActive(true);
        doors_closed.gameObject.SetActive(false);

    }

}
