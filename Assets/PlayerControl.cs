using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float HorizontalTurnSpeed;
    public bool paused;

    private float XInput;
    private float ZInput;
    private float startX;
    private float startY;
    private float startZ;
    private bool jump;
    private bool pauseHold;

    // Start is called before the first frame update
    void Start()
    {
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Escape") && paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else if (Input.GetButtonDown("Escape") && !paused)
        {
            Time.timeScale = 0;
            paused = true;
        }
        if (!paused)
        {
            playerMovement();
            playerRotation();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void playerMovement()
    {
        XInput = Input.GetAxis("Horizontal");
        ZInput = Input.GetAxis("Vertical");

        //moves player
        transform.Translate(Vector3.forward * Time.deltaTime * ZInput * moveSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * XInput * moveSpeed);

        //makes player jump
        if(Input.GetButton("Jump") && !jump)
        {
            jump = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 7.5f, 0);
        }

        if (transform.position.y < -10)
            transform.position = new Vector3(startX, startY, startZ);
        //checks if player is sprinting
        if (Input.GetButton("Sprint"))
            moveSpeed = 6;
        else
            moveSpeed = 3;
    }

    void playerRotation()
    {
        //rotates on horizontal axes
        transform.eulerAngles += HorizontalTurnSpeed * new Vector3(0, Input.GetAxis("Mouse X"), 0);

        //fixes z axis (prevents camera flipping)
        if (transform.localRotation.eulerAngles.z > 0)
            transform.eulerAngles = new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            jump = false;
        }
    }
}