using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    Room parent_room_script;
    public GameObject exit_room;
    public GameObject main_camera;

    private Vector3 horizontal_offset = new(30.0f, 0, 0);
    private Vector3 vertical_offset = new(0.0f, 0, 17.7f);

    void Start()
    {
        main_camera = GameObject.Find("Main Camera");
        parent_room_script = GetComponentInParent<Room>();
        if(!parent_room_script.is_empty) {
            GetComponent<BoxCollider>().isTrigger = false;
        }
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
                    Debug.Log("Updated");
                    break;
                case "ExitLeft":
                    other.GetComponent<PlayerMovement>().Teleport(exit_room.GetComponent<Room>().exit_right.transform.position);
                    Debug.Log("Updated");
                    break;
                case "ExitRight":
                    other.GetComponent<PlayerMovement>().Teleport(exit_room.GetComponent<Room>().exit_left.transform.position);
                    Debug.Log("Updated");
                    break;
                default:
                    break;
            }
            main_camera.GetComponent<CameraController>().SetCameraXZCoords(exit_room.GetComponent<Room>().middle.position);

        }
    }
}