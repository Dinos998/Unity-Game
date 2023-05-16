using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;
    void OnTriggerEnter(Collider other)
    {
        GameEvents.current.DoorwayTriggerEnter(id);
    }

    void OnTriggerExit(Collider other)
    {
        GameEvents.current.DoorwayTriggerExit(id);
    }
}
