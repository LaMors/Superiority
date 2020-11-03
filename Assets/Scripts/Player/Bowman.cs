using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bowman : Units, IPointerClickHandler
{
    private void OnEnable()
    {
        Name = "Bowman";
        MovingRange = 3;
        AttackRange = 3;
        Damage = 1;
        ArmorPiercing = 0;
        HitPoints = 1;
        Armor = 0;
        Initiative = 4;
        Visibility = 5;
        PriceInPeople = 10;
        PriceInEquipment = 5;
        FoodsPerTurn = 5;
       
    }
}
