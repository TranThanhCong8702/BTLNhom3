using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TuDoPopup : MonoBehaviour
{
    public Button btnClose;
    public Button btnGunMoney;
    public Button btnMoney;
    public Button btnAtm; 
    public Button btnCat; 
    public ItemManager itemManager;

    private void Awake()
    {
        btnClose.onClick.AddListener(() => gameObject.SetActive(false));
        btnGunMoney.onClick.AddListener(() => itemManager.SetItemToHand("GunMoney"));
        btnMoney.onClick.AddListener(() =>
        {
            itemManager.SetItemToHand("Money");
        });
        btnAtm.onClick.AddListener(() => itemManager.SetItemToHand("AtmCard"));
        btnCat.onClick.AddListener(() => itemManager.SetItemToHand("Cat"));
    }
}
