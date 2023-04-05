using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int Price;
    public int Cost;
    public int Income;
    public int Happines;
    float CheckHappines = 5f;

    [SerializeField] Transform[] RayPoints;
    [SerializeField] GameObject LeftWall;
    [SerializeField] GameObject RightWall;
    [SerializeField] GameObject LeftDoorWall;
    [SerializeField] GameObject RightDoorWall;
  
    void Update()
    {
        //decrease the happines of the room by one each 5 seconds.
        CheckHappines -= Time.deltaTime;
        if (CheckHappines < 0 && Happines > 0)
        {
            CheckHappines = 5;
            Happines--;
        }

        DetectWalls();
    }
    /// <summary>
    /// DetectWalls() function will use Raycast for the next near room to choose the room wall:
    /// if the same room --> no wall.
    /// if other kind of room --> room with door.
    /// if there is no room --> solid wall. 
    /// </summary>
    void DetectWalls()
    {
        if (Physics.Raycast(RayPoints[0].position, Vector3.right,out RaycastHit hitInfo, 0.6f))
        {
            LeftWall.SetActive(false);
            
            if (hitInfo.collider.gameObject.tag != gameObject.tag)
            { 
                LeftDoorWall.SetActive(true);  
            }
        }
        else 
        {
            LeftWall.SetActive(true);
            LeftDoorWall.SetActive(false);
        }


        if (Physics.Raycast(RayPoints[1].position, Vector3.left, out RaycastHit hitInfo2, 0.6f))
        {
            RightWall.SetActive(false);
            
            if (hitInfo2.collider.gameObject.tag != gameObject.tag)
            {

                RightDoorWall.SetActive(true);
              
            }
        }

        else 
        {
            RightWall.SetActive(true); 
            RightDoorWall.SetActive(false);
        }
    }
}
