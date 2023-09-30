using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public int Damage = 0;
    public AmmoType ammoType = AmmoType.None;
}
