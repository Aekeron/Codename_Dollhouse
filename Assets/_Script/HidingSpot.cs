using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    [Header("Character Properties")]
    [SerializeField]
    Transform hideTransform;

    [SerializeField]
    float xLockValue;

    [SerializeField]
    float yLockValue;

    Transform cameraPlay;
    Transform playerTran;

    float pitch = 0;
    float yaw = 0;

    [SerializeField]
    float zOffset;

    public void HideAtSpot(Transform player, Transform camera)
    {
        player.position = hideTransform.position;
        player.rotation = hideTransform.rotation;

        cameraPlay = camera;
        playerTran = player;

        cameraPlay.localEulerAngles = Vector3.zero;
    }

    public void StopHidingAtSpot()
    {
        playerTran.position += playerTran.forward * zOffset;
        cameraPlay = null;
        playerTran = null;
    }

    public void Update()
    {
        if(cameraPlay != null)
        {
            pitch = Mathf.Clamp(pitch - Input.GetAxis("Mouse Y"), -yLockValue, yLockValue);
            yaw = Mathf.Clamp(yaw + Input.GetAxis("Mouse X"), -xLockValue, xLockValue);

            Vector3 euler = new Vector3(pitch, yaw, 0);

            cameraPlay.localEulerAngles = euler;
        }

        if(playerTran != null)
        {
            playerTran.position = hideTransform.position;
            playerTran.rotation = hideTransform.rotation;
        }
    }

}
