﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class AStarSearch
{
    public List<GraphVertex> closed = new List<GraphVertex>();

    public List<GraphVertex> open = new List<GraphVertex>();


    public Dictionary<GraphVertex, float> costSoFar
       = new Dictionary<GraphVertex, float>();

    public List<Cell> StartSearch(GraphVertex start, GraphVertex finish)
    {
        open.Add(start);

        start.Priority = GetHeuristicCost(start, finish);
     
        costSoFar[start] = 0;


        while (open.Count > 0)
        {
            var current = open.OrderBy(s => s.Priority).First();

            open.Remove(current);

            closed.Add(current);

            if (current.Equals(finish))
            {
                return ReconstructPath(start, finish);
            }

            

            var neighbors = current.Edges.
                Select(s => s.ConnectedVertex).
                OrderBy(s => !closed.Contains(s));

            foreach (var neighbor in neighbors)
            {
                float newCost = costSoFar[current] + neighbor.Cell.State.PassageDifficulty.Value;

                if (closed.Contains(neighbor) && newCost >= costSoFar[neighbor])
                    continue;

                
                if (!open.Contains(neighbor) || newCost < costSoFar[neighbor])
                {
                    costSoFar[neighbor] = newCost;

                    neighbor.Priority = newCost + GetHeuristicCost(neighbor, finish);

                    if (!open.Contains(neighbor))
                        open.Add(neighbor);

                    neighbor.СameFrom = current;
                }
            }
        }


        throw new Exception("путь не найден");
    }

    private float GetHeuristicCost(GraphVertex start, GraphVertex finish)

    {
        return (float)Math.Sqrt(Math.Pow((start.VertexCoordinates.x - finish.VertexCoordinates.x), 2d) + Math.Pow((start.VertexCoordinates.y - finish.VertexCoordinates.y), 2d));
    }

    private List<Cell> ReconstructPath(GraphVertex start, GraphVertex finish) 
    {

        GraphVertex current = finish.СameFrom;

        var _way = new List<GraphVertex>();

        int fuse = 0;

        while (!current.Equals(start))
        {
            fuse++;

            if (fuse == 1000000)
                throw new Exception("Ходим по кругу");

            current.Cell.SetLight(true);

            _way.Add(current);

            current = current.СameFrom;
        }
        _way.Reverse();

        var ReconstructPath = _way.Select(s => s.Cell).ToList();

        foreach (var item in ReconstructPath)
        {
        }

        return ReconstructPath;
    }
}

