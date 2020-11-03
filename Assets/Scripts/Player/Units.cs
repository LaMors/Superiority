using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using System.Collections;

abstract public class Units : MonoBehaviour, IPointerClickHandler
{
    public static List<GameObject> UnitsCollections = new List<GameObject>();

    public string Name { get; protected set; }
    public int MovingRange { get; protected set; }
    public int AttackRange { get; protected set; }
    public int Damage { get; protected set; }
    public int ArmorPiercing { get; protected set; }
    public int HitPoints { get; protected set; }
    public int Armor { get; protected set; }
    public int Initiative { get; protected set; }
    public int Visibility { get; protected set; }
    public int PriceInPeople { get; protected set; }
    public int PriceInEquipment { get; protected set; }
    public int FoodsPerTurn { get; protected set; }
    public Vector3 UnitPosition { get; protected set; }


    protected bool _isMoving = false;
    protected Transform _transformUnit;
    protected float _speed = 5f;
    protected RaycastProcessor _raycastProcessor;
    protected Cell _cell;

    protected void Awake()
    {
        _transformUnit = GetComponent<Transform>();
        _raycastProcessor = new RaycastProcessor();
    }
   

    public void Moving(Vector3 cellPosition)
    {

        if (_transformUnit.position != cellPosition)
        {
            SetlightCells(false);

            SetRadiusMotion(false, Color.white );

            StartCoroutine(Example(cellPosition));

            _cell = GetMyCell();

        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {

        _cell = GetMyCell();

        EventUnits.SetUnitSelected(this);

        SetlightCells(true);

        SetRadiusMotion(true, Color.green);


    }

    protected virtual void SetlightCells(bool isLight)
    {

        foreach (var item in Cell.CellsCollections)
        {
            Cell cell = item.GetComponent<Cell>();

            if (Math.Abs(Vector3.Distance(_cell.Transform.position, cell.Transform.position)) <= (Visibility + _cell.State.SurveyRangeBonus.Value) * cell.Radius * 2)
            {

                cell.SetLight(isLight);

            }

        }
    }

    protected virtual void SetRadiusMotion(bool isPassable, Color color)
    {

        foreach (var item in Cell.CellsCollections)
        {
            Cell cell = item.GetComponent<Cell>();

            if (Math.Abs(Vector3.Distance(_transformUnit.position, cell.Transform.position)) <= ((MovingRange + cell.State.PassageDifficulty.Value) * cell.Radius*2))
            {

                cell.IsPassable = isPassable;
                cell.SetColor(color);
            }

        }
    }

    protected virtual Cell GetMyCell()
    {
        GameObject[] hitObjects = _raycastProcessor.GetObjects(_transformUnit.position);

        foreach (var hitObject in hitObjects)
        {
            Cell cell = hitObject.GetComponent<Cell>();

            if (cell != null)
            {
                return cell;
            }
          
        }
        throw new Exception("Клетка на которой стоит юнит не найдена");
    }


    IEnumerator Example(Vector3 cellPosition)
    {
        float currentMovementTime = 0;
        while ((_transformUnit.position != cellPosition))
        {
            currentMovementTime += Time.deltaTime;
            _transformUnit.position = Vector3.Lerp(_transformUnit.position, cellPosition, currentMovementTime / _speed);
            yield return null;
        }

        _transformUnit.position = new Vector3(_transformUnit.position.x, _transformUnit.position.y, 0f);

        _cell = GetMyCell();

        SetlightCells(true);

        SetRadiusMotion(true, Color.green);
    }
}



