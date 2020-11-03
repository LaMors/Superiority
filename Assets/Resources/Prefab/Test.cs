using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    Cell start;
    Cell finish;
    int i = 0;

    private void OnEnable()
    {
        EventAggregator.Test += EventAggregator_Test;
    }



    private void OnDisable()
    {
        EventAggregator.Test -= EventAggregator_Test;
    }


    private void EventAggregator_Test(Cell newCell, bool flag)
    {
        if (i == 1)
        {
            finish = newCell;
            i = 0;
            var AStar = new AStarSearch();
            var map = AStar.StartSearch(start.GraphVertex, finish.GraphVertex);
            
        }
        else
        {
            start = newCell;
            i++;
        }
    }
}
