using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InformationPanelManager : MonoBehaviour 
{
    [SerializeField]
    private List<GameObject> _informationIcons;
    

    private void OnEnable()
    {
        EventAggregator.CellResursInThePanel += SummonPrintResourcesMethod;
    }

    private void OnDisable()
    {
        EventAggregator.CellResursInThePanel -= SummonPrintResourcesMethod;
    }

    private void SummonPrintResourcesMethod(List<ResourcesInformation> _resourcesInformation, List<TextInformation> _textInformation)
    {
        SelectionIcon(_resourcesInformation);
        SelectionIcon(_textInformation);
    }

    private void SelectionIcon(List<ResourcesInformation> _resourcesInformation)
    {

        foreach (var icon in _informationIcons)
        {
            var result = _resourcesInformation.FirstOrDefault(s => s.Name == icon.name);

            if (result != null && icon != null)
            {
                PrintResours(result?.Value, icon);
            }
        }

    }


    private void SelectionIcon(List<TextInformation> _textInformation)
    {

        foreach (var icon in _informationIcons)
        {
            var result = _textInformation.FirstOrDefault(s => s.Name == icon.name);

            if (result != null && icon != null)
            {
                PrintResours(result?.Value, icon);
            }
        }

    }


    private void PrintResours<T>(T resoursValue, GameObject icon)

    {
            icon.GetComponentInChildren<Text>().text = resoursValue.ToString();   
    }
}
