using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    [SerializeField] Transform[] RayPoints;
    [SerializeField] GameObject Warning;

    Camera m_Camera;
    Vector3 targetPos;
    bool IsPlaced;
    bool trigger;
   

    void Start()
    {
         m_Camera = Camera.main;
    }

    void Update()
    {
        DetectMove();
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsPlaced) { return; }
        trigger = true;
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (IsPlaced) { return; }
        trigger = false;
    }

    /// <summary>
    /// this function used to let the room follow the mouse until placed it. 
    /// </summary>
    void DetectMove()
    {
            if (IsPlaced) { return; }

            Vector3 mouse = Input.mousePosition;
            mouse.z = 5;
            targetPos = m_Camera.ScreenToWorldPoint(mouse);
            targetPos.z = Mathf.Round(targetPos.z);
            targetPos.x = Mathf.Round(targetPos.x);
            targetPos.y = Mathf.Round(Mathf.Clamp(targetPos.y, 0f, 50f));
            transform.position = targetPos;

            if (IsValidPos() && Input.GetMouseButtonDown(0))
            {
                IsPlaced = true;
            }
    }

    /// <summary>
    /// this function use Raycast to detect the validity of the room position.
    /// </summary>
    /// <returns></returns>
    bool IsValidPos()
    {
        if (trigger) {    
            Warning.SetActive(true);
            return false; 
        }

        for(int i = 0; i < RayPoints.Length; i++)
        {
            if(!Physics.Raycast(RayPoints[i].position, Vector3.down, 1f))
            {
                Warning.SetActive(true);
                return false;
            }

        }
        Warning.SetActive(false);
        return true;
    }
   
}
