using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering.Universal;

public class Manager : MonoBehaviour
{
    
    [SerializeField] GameObject Holder;
    [SerializeField] TextMeshProUGUI TxtHappiness;
    [SerializeField] TextMeshProUGUI TxtWallet;
    [SerializeField] TextMeshProUGUI Bonus;

    List<GameObject> AddedRooms = new List<GameObject>();

    float Timer = 1f;
    float CheckBonus=10f;
   
    int TotalIncome;
    int TotalCost;
    
    int Happines=0;
    int Wallet=50;

    bool NewRoom;
    void Update()
    {
        Timer -= Time.deltaTime;
        CheckBonus -= Time.deltaTime;
       

        if (Timer < 0)
        {
            Timer = 1;
            UpdateInfo();
        }
      
       
        if (CheckBonus < 0)
        {
            CheckBonus = 10;
            if (NewRoom)
            {
                if (TotalIncome > TotalCost)
                {

                    StartCoroutine(BonusFunc());

                }   
            }
        }
      
        TxtHappiness.text = "Happines : " + Happines.ToString();
        TxtWallet.text = "Wallet : " + Wallet.ToString()+" $";
    }
    /// <summary>
    /// this function will be called when the TotalIncome > TotalCost, to give the player 5$ bonus.
    /// </summary>
    /// <returns></returns>
    IEnumerator BonusFunc()
    {
        Wallet += 5;
        Bonus.text = "+5$";
        NewRoom = false;
        yield return new WaitForSeconds(3);
        Bonus.text = " ";
    }
    /// <summary>
    /// this function will be called each second to update the wallet & happines.
    /// </summary>
   void UpdateInfo()
    {
        foreach (GameObject Room in AddedRooms)
        {
            Wallet -= Room.GetComponent<Room>().Cost;
            TotalCost += Room.GetComponent<Room>().Cost;
            Wallet += Room.GetComponent<Room>().Income;
            TotalIncome += Room.GetComponent<Room>().Income;
            Happines += Room.GetComponent<Room>().Happines;   
        }
    }

    /// <summary>
    /// this function will be called by the UI Rooms Btns, 
    /// will take room type and Instantiate (bay) it and store it in the list
    /// </summary>
    /// <param name="room"></param>
    public void GenerateRome(GameObject room)
    {
          NewRoom = true;
         if (Wallet >= room.GetComponent<Room>().Price)
         {
            GameObject obj = Instantiate(room, Holder.transform);
            Wallet -= obj.GetComponent<Room>().Price;
            AddedRooms.Add(obj);
         }
       
    }
}
