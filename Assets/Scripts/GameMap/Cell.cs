using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Linq;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    public static GameObject[,] CellsCollections;

    
    public Vector2Int Index 
    {
        get 
        {
            return _index;
        }
        set
        {
            _index = value;
        } 
    }

    public float Radius { get; set; }
    public CellState State { get; set; }
    public bool IsPassable { get; set; }

    public GraphVertex GraphVertex { get; private set; }

    public Transform Transform { get; private set; }

    public List<Vector2Int> neighborsCor;

    [SerializeField]
    private Vector2Int _index;

    [SerializeField]
    private List<Material> _materials;

    public LineRenderer _line;
    private string _name;
    private List<TextInformation> _textInformation;
    private List<ResourcesInformation> _resourcesInformation;
    private Light _light;
    private Units _unit;


    bool flag;
    private void OnEnable()
    {
        EventUnits.UnitSelected += EventUnits_UnitSelected;
    }

   

    private void OnDisable()
    {
        EventUnits.UnitSelected -= EventUnits_UnitSelected;
    }

    

    private void EventUnits_UnitSelected(Units unit)
    {
        _unit = unit;
    }


    private void Start()
    {
        _name = GetComponent<SpriteRenderer>().sprite.name;

        Transform = GetComponent<Transform>();

        _line = GetComponentInChildren<LineRenderer>();

        State = new CellState();

        GraphVertex = GetComponent<GraphVertex>();

        _light = GetComponentInChildren<Light>();

        SetSpecification(_name);

        _textInformation = State.GetTextInformation();

        _resourcesInformation = State.GetResourcesInformation();

        GraphVertex.VertexCoordinates = Index;

        GraphVertex.Cell = this;

        StartCoroutine(Example());
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        EventAggregator.SummonPanelVisibility("InfoList", true);

        EventAggregator.SummonCellResourcesInThePanel(_resourcesInformation, _textInformation);

        EventCreationObject.UnitPosition(Transform.position);

        EventAggregator.SummonTest(this, true);

        if (IsPassable)
        {
            _unit.Moving(Transform.position);
        }
        
    }

    private void SetSpecification(string _name)
    {
        State.CheckTheStatus(this, _name);
    }

    public void SetColor(Color color)
    {

        //GetComponent<SpriteRenderer>().color = color;
        _light.color = color;
    }

    public void SetLight(bool isLight)
    {
        _light.enabled = isLight;
    }

    public void SetMaterial(string materialName)
    {
        foreach (var material in _materials)
        {
            if (material.name == materialName)
            {
                GetComponentInChildren<SpriteRenderer>().material = material;
            } 
        }
       
    }

    private void СonnectionsWithNeighbors()
    {
        var effector = new CoordinateManager();

        var neighbors = effector.GetNeighbors(_index);

        foreach (var neighbor in neighbors)
        {
            neighborsCor.Add(neighbor.Index);
            

            GraphVertex.AddEdge(neighbor.GraphVertex, neighbor.State.PassageDifficulty.Value);

        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(0.1f);
        СonnectionsWithNeighbors();
    }

    public void Test() { 
    }
}