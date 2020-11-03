using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public List<GraphVertex> Vertices { get; private set;}


    public static Graph Instance;

    private Graph()
    { }

    public static Graph getInstance()
    {
        if (Instance == null)
            Instance = new Graph();
        return Instance;
    }


    private void Awake()
    {
        Instance = this;
        Vertices = new List<GraphVertex>();
    }

    public void AddVertex(GraphVertex vertex)
    {
        Vertices.Add(vertex);
    }

    public GraphVertex FindVertex(Vector2 vertexCoordinates)
    {
        foreach (var v in Vertices)
        {
            if (v.VertexCoordinates.Equals(vertexCoordinates))
            {
                return v;
            }
        }

        return null;
    }

    public void AddEdge(GraphVertex firstVertex, GraphVertex secondVertex, int weight)
    {

        if (firstVertex != null && secondVertex != null )
        {
            firstVertex.AddEdge(secondVertex, weight);
            secondVertex.AddEdge(firstVertex, weight);
        }
    }
}
