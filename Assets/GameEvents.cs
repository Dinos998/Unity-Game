using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public event Action<int> onDoorwayTriggerEnter;
    public event Action<int> onDoorwayTriggerExit;

    private void Awake()
    {
        current = this;
    }

    public void DoorwayTriggerEnter(int id)
    {
        onDoorwayTriggerEnter?.Invoke(id);
    }

    public void DoorwayTriggerExit(int id)
    {
        onDoorwayTriggerExit?.Invoke(id);
    }
}
