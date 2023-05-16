using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public DoorController myDoorController;
    public int id;
    public int secondsOpen;
    public Material idleMat;
    public Material pushMat;

    void Start()
    {
        idleMat = GetComponent<Renderer>().material;
        this.id = myDoorController.id;
    }

    void OnTriggerStay(Collider other)
    {
        myDoorController.timeOpened = secondsOpen;
        GameEvents.current.DoorwayTriggerEnter(id);
        GetComponent<Renderer>().material = pushMat;
    }

    void OnTriggerExit(Collider other)
    {
        GameEvents.current.DoorwayTriggerExit(id);
        GetComponent<Renderer>().material = idleMat;
    }
}
