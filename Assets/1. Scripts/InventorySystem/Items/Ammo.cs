using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum AmmoType
{
    None,
    Pistol,
    Assault_rifle
}

[CreateAssetMenu(fileName = "Ammo", menuName = "Items/Ammo")]
public class Ammo : Item
{
    public AmmoType type = AmmoType.None;
}
