using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -3);
    public float sensitivity = 2f;
    public float distance = 3f;

    private float pitch = 0f;
    private float yaw = 0f;

    private bool isCursorLocked = true; // Tracks cursor lock state

    void Start()
    {
        // Set initial cursor state
        SetCursorState(true);

        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update()
    {
        // Toggle cursor lock state on "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorLocked = !isCursorLocked;
            SetCursorState(isCursorLocked);
        }

        // Only allow camera rotation when the cursor is locked
        if (isCursorLocked)
        {
            yaw += Input.GetAxis("Mouse X") * sensitivity;
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;
            pitch = Mathf.Clamp(pitch, -45f, 75f);
        }
    }

    void LateUpdate()
    {
        if (isCursorLocked)
        {
            Vector3 desiredPosition = player.position - (Quaternion.Euler(pitch, yaw, 0) * Vector3.forward * distance);
            desiredPosition += Vector3.up * offset.y;

            transform.position = desiredPosition;
            transform.LookAt(player.position + Vector3.up * 1.5f);
        }
    }

    // Method to set cursor state (locked or unlocked)
    void SetCursorState(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Method to get camera's forward direction
    public Vector3 GetCameraForward()
    {
        Vector3 forward = transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }

}