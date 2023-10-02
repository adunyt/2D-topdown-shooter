using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarConroller : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private Slider HPBar;

    private float currentHP;
    private int maxHP;
    private float test;

    private void Awake()
    {
        maxHP = entity.GetMaxHP();   
    }

    public void UpdateHP()
    {
        print("updating HP");
        currentHP = entity.GetCurrentHP();
        HPBar.value = currentHP / maxHP;
        test = HPBar.value;
    }
}
