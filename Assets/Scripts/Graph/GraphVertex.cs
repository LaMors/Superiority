using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphVertex : MonoBehaviour
{
    public Cell Cell { get; set; }

    public float Priority { get; set; }

    public GraphVertex СameFrom;

    private Vector2Int _vertexCoordinates;

    public Vector2Int VertexCoordinates 
    {
        get 
        {
            if (_vertexCoordinates != null)
                return _vertexCoordinates;
            else
                throw new System.Exception("No vertex coordinates");
        }
        set
        {
            _vertexCoordinates = value;
        }
    }

    public List<GraphEdge> Edges { get; private set; }

    private void Awake()
    {
        Edges = new List<GraphEdge>();
    }

    private void Start()
    {
        Graph.Instance.AddVertex(this);
        
    }

    public void AddEdge(GraphEdge newEdge)
    {
        Edges.Add(newEdge);
    }

    public void AddEdge(GraphVertex vertex, int edgeWeight)
    {
        AddEdge(new GraphEdge(vertex, edgeWeight));
    }

}
