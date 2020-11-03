using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInfo : MonoBehaviour
{
    private string _name;

    public void OnClic()
    {
        _name = gameObject.transform.parent.gameObject.name;
        EventAggregator.SummonPanelVisibility(_name, false);
    }
}
