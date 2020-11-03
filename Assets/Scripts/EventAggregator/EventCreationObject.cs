using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SetUnit(string unitName);

public delegate void SetUnitPosition(Vector3 CellPosition);

public class EventCreationObject : MonoBehaviour

{

    public static event SetUnitPosition SetUnitPositionEvent;

    public static void UnitPosition(Vector3 CellPosition)
    {
        SetUnitPositionEvent?.Invoke(CellPosition);
    }

    public static event SetUnit SetUnitEvent;

    public static void SetUnit(string unitName)
    {
        SetUnitEvent?.Invoke(unitName);
    }
}



