using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Transform leftHand;

    public void SetItemToHand(string itemName)
    {
        for (int i = 0; i < leftHand.childCount; i++)
        {
            leftHand.GetChild(i).gameObject.SetActive(false);
        }

        if (itemName == "GunMoney")
        {
            leftHand.GetChild(0).gameObject.SetActive(true);
        }
        else if (itemName == "Money")
        {
            leftHand.GetChild(1).gameObject.SetActive(true);
        }
        else if (itemName == "AtmCard")
        {
            leftHand.GetChild(2).gameObject.SetActive(true);
        }
        else if (itemName == "Cat")
        {
            
        }
    }
}
