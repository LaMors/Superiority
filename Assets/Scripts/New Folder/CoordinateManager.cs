using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateManager
{

   public List<Cell> GetNeighbors(Vector2Int indexCell)
    {

        List<Cell> _negrNeighbors = new List<Cell>();

        if ((indexCell.x & 1) == 1)
        {
            if (indexCell.x != 0)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x-1, indexCell.y].GetComponent<Cell>());
            }

            if (indexCell.x != 0 && indexCell.y != Cell.CellsCollections.GetLength(1) - 1 )
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x-1, indexCell.y+1].GetComponent<Cell>());
            }

            if (indexCell.y != 0)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x, indexCell.y - 1].GetComponent<Cell>());
            }

            if (indexCell.y != Cell.CellsCollections.GetLength(1) - 1)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x, indexCell.y + 1].GetComponent<Cell>());
            }

            if (indexCell.x != Cell.CellsCollections.GetLength(0) - 1)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x + 1, indexCell.y].GetComponent<Cell>());
            }

            if (indexCell.x != Cell.CellsCollections.GetLength(0) - 1 && indexCell.y != Cell.CellsCollections.GetLength(1) - 1)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x + 1, indexCell.y+1].GetComponent<Cell>());
            }
        }

        else
        {
            if (indexCell.x != 0 && indexCell.y != 0)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x - 1, indexCell.y-1].GetComponent<Cell>());
            }

            if (indexCell.x != 0)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x-1 , indexCell.y].GetComponent<Cell>());
            }

            if (indexCell.y != 0)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x, indexCell.y - 1].GetComponent<Cell>());
            }

            if (indexCell.y != Cell.CellsCollections.GetLength(1) - 1)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x, indexCell.y + 1].GetComponent<Cell>());
            }

            if (indexCell.x != Cell.CellsCollections.GetLength(0) - 1 && indexCell.y != 0)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x+1, indexCell.y-1].GetComponent<Cell>());
            }

            if (indexCell.x != Cell.CellsCollections.GetLength(0) - 1)
            {
                _negrNeighbors.Add(Cell.CellsCollections[indexCell.x + 1, indexCell.y].GetComponent<Cell>());
            }
        }
        

        if (_negrNeighbors == null)
        {
            throw new System.Exception("Не найдено соседей клетки");
        }
        return _negrNeighbors;
    }
}
