using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 targetPos;
   
    void Start()
    {
        targetPos=transform.position;
    }

    /// <summary>
    /// update method will detect the user movement to move the camera. 
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && targetPos.y < 100)
        {
            targetPos.y++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && targetPos.y >3)
        {
            targetPos.y--;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && targetPos.x < 6)
        {
            targetPos.x++;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && targetPos.x > -6)
        {
            targetPos.x--;
        }

        transform.position = targetPos;
    }
}
