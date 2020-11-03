using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UnitBottom : MonoBehaviour
{

    [SerializeField]

        public void ActionUnitPanel()
    {
        EventAggregator.SummonPanelVisibility("UnitList", true);
    }
}
