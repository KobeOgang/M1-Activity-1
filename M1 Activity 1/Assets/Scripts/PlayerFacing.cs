using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacing : MonoBehaviour
{
    public ThirdPersonCamera cameraController;
    public float rotationSpeed = 10f;


    void Update()
    {

            Vector3 cameraForward = cameraController.GetCameraForward();

            if (cameraForward.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

    }
}
