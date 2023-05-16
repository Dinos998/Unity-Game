using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public DoorController myDoorController;
    public int id;
    public int secondsOpen;

    // Start is called before the first frame update
    void Start()
    {
        this.id = myDoorController.id;
    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 0.5f, transform.eulerAngles.z);
    }

    void OnTriggerEnter(Collider other)
    {
        myDoorController.timeOpened = secondsOpen;
        GameEvents.current.DoorwayTriggerEnter(id);
        foreach (GameObject key in GameObject.FindGameObjectsWithTag("Key"))
            GameObject.Destroy(key);
        Destroy(this);
    }
}
