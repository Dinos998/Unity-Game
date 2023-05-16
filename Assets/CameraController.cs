using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float YOffset;
    public float YSensitivity;
    public float YBottom;
    public float YTop;

    public PlayerControl player;

    void Start()
    {
        if (YSensitivity <= 0)
            Debug.Break();
        Looking();
    }

    void LateUpdate()
    {
        if(!(player.paused))
        {
            YOffset = YOffset + (Input.GetAxis("Mouse Y") * YSensitivity);
            Looking();
        }
    }

    void Looking()
    {
        if (YOffset <= YBottom)
            YOffset = YBottom;
        if (YOffset >= YTop)
            YOffset = YTop;
        transform.LookAt(player.transform.position + new Vector3(0, YOffset, 0));
    }
}
