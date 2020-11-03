using System.Collections.Generic;


public delegate void GiveCellStateInThePanel (List<ResourcesInformation> _resourcesInformation, List<TextInformation> _textInformation);

public delegate void PanelVisibility(string panelName, bool panelStatus);

public delegate void TestDel(Cell cell, bool flag);



public static class EventAggregator
{
    public static event GiveCellStateInThePanel CellResursInThePanel;

    public static void SummonCellResourcesInThePanel(List<ResourcesInformation> _resourcesInformation, List<TextInformation> _textInformation)
    {

        CellResursInThePanel?.Invoke(_resourcesInformation, _textInformation);

    }


    public static event PanelVisibility PanelVisibility;

    public static void SummonPanelVisibility(string panelName, bool panelStatus)
    {

        PanelVisibility?.Invoke(panelName, panelStatus);
    }

    public static event TestDel Test;

    public static void SummonTest (Cell cell, bool flag)
    {
        Test?.Invoke(cell, flag);
    }


}