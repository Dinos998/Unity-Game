using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    public int time;
    public bool open;
    public int timeOpened;
    public new Renderer renderer;

    private void Start()
    {
        this.renderer = GetComponent<Renderer>();
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
        InvokeRepeating("timeOpen", 0, 1);
    }

    void LateUpdate()
    {
        if (open && transform.localPosition.y < 5 || timeOpened > -1)
        {
            if (transform.localPosition.y > 5)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 5, transform.localPosition.z);
                renderer.enabled = false;
            }
            else
                transform.Translate(Vector3.up * Time.deltaTime * 4);
        }
        else if (!open && transform.localPosition.y > 2 && timeOpened <= -1)
        {
            if (transform.localPosition.y < 2)
                transform.localPosition = new Vector3(transform.localPosition.x, 2, transform.localPosition.z);
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * 4);
                renderer.enabled = true;
            }
            
        }
    }

    void OnDoorwayOpen(int id)
    {
        if(id == this.id)
        {
            open = true;
        }
    }

    void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            open = false;
        }
    }

    void onDestroy()
    {
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit -= OnDoorwayClose;
    }

    void timeOpen()
    {
        if(timeOpened >= 0)
            timeOpened--;
    }
}
