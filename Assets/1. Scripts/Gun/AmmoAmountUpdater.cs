using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoAmountUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private GunController gunController;

    private void Awake()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        print("update ammo amount ui");
        label.text = $"{gunController.GetCurrentAmmoAmount()}/{gunController.GetMaxAmmoAmount()}";
    }
}
