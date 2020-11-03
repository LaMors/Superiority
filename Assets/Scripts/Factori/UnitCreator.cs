using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreator: MonoBehaviour, ICreator
{

    [SerializeField]
    private List<GameObject> _units;

    private GameObject _unit;

    private Vector3 _cellPosition = new Vector3(0, 0, 0);
    private void OnEnable()
    {
        EventCreationObject.SetUnitEvent += EventAggregator_SetUnit;

        EventCreationObject.SetUnitPositionEvent += EventCreationObject_SetUnitPositionEvent;
    }

   
    private void OnDisable()
    {
        EventCreationObject.SetUnitEvent -= EventAggregator_SetUnit;

        EventCreationObject.SetUnitPositionEvent -= EventCreationObject_SetUnitPositionEvent;

    }

    private void EventAggregator_SetUnit(string unitName)
    {

        _unit = UnitSelection(unitName);

        Create(_cellPosition.x, _cellPosition.y, _unit);
    }

    public void Create(float x, float y, GameObject unit)
    {

        if (unit != null)
        {
            Units.UnitsCollections.Add(Instantiate(unit, new Vector3(x, y, 0.9f), Quaternion.identity));
        }
        

    }

   private GameObject UnitSelection(string unitName)
    {
        foreach (var unit in _units)
        {

           if (unit.name == unitName)
           {
                return unit;
           }
        }
        return _units[0];
    }

    private void EventCreationObject_SetUnitPositionEvent(Vector3 CellPosition)
    {
        _cellPosition = CellPosition;
    }



}
