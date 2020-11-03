using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> panels;

    private void OnEnable()
    {
        EventAggregator.PanelVisibility += EventAggregator_InfoPanelVisibility;
    }

   

    private void OnDisable()
    {
        EventAggregator.PanelVisibility -= EventAggregator_InfoPanelVisibility;
    }


    private void EventAggregator_InfoPanelVisibility(string panelName, bool panelStatus)
    {
        int i = 0;

        foreach (var panel in panels)
        {
            
            if (panel.name == panelName || panelName == "All")
            {
                panel.SetActive(panelStatus);

                i++;
            }
            else if  (panels.Count == i)
            {
                throw new Exception($"Вызваная {panelName} не найдена");
            }
            
        }
        
    }



}
