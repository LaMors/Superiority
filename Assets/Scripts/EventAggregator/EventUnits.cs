using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UnitSelected(Units unit);

public static class EventUnits
{

    public static event UnitSelected UnitSelected;

    public static void SetUnitSelected(Units unit)
    {
        UnitSelected?.Invoke(unit);
    }

}
