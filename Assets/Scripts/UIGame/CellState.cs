using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellState
{
    public TextInformation Name { get; protected set; }

    public TextInformation Master { get; protected set; }

    public ResourcesInformation FoodExtraction { get; protected set; }

    public ResourcesInformation PassageDifficulty { get; protected set; }

    public ResourcesInformation ProtectionBonus { get; protected set; }

    public ResourcesInformation ProtectionDecline { get; protected set; }

    public ResourcesInformation SurveyRangeBonus { get; protected set; }

    public ResourcesInformation ShotRangeBonus { get; protected set; }

    public ResourcesInformation OreQuantity { get; protected set; }

    public virtual void  CheckTheStatus(Cell _cell, string _name)
    {
        if (_name == "Ice")
        {
            _cell.State = new IceCell();
        }

        else if (_name == "Ocean")
        {
            _cell.State = new OceanCell();
        }

        else if (_name == "Water")
        {
            _cell.State = new WaterCell();
        }

        else if (_name == "Tundra")
        {
            _cell.State = new TundraCell();
        }

        else if (_name == "Steppe")
        {
            _cell.State = new SteppeCell();
        }

        else if (_name == "Forest")
        {
            _cell.State = new ForestCell();
        }

        else if (_name == "Undergrowth")
        {
            _cell.State = new UndergrowthCell();
        }

        else if (_name == "Plain")
        {
            _cell.State = new PlainCell();
        }

        else if (_name == "Swamp")
        {
            _cell.State = new SwampCell();
        }

        else if (_name == "Jungle")
        {
            _cell.State = new JungleCell();
        }

        else if (_name == "Sand")
        {
            _cell.State = new SandCell();
        }

        else if (_name == "Desert")
        {
            _cell.State = new DesertCell();
        }

        else if (_name == "Savannah")
        {
            _cell.State = new SavannahCell();
        }

        else if (_name == "Dune")
        {
            _cell.State = new DuneCell();
        }

        else if (_name == "Hills")
        {
            _cell.State = new HillsCell();
        }

        else if (_name == "DesertMountains")
        {
            _cell.State = new DesertMountainsCell();
        }

        else if (_name == "Mountain")
        {
            _cell.State = new MountainCell();
        }

        else
        {
            throw new System.Exception("Не найдено класса для клетки");
        }

    }


    public virtual List<ResourcesInformation> GetResourcesInformation()
    {
        List<ResourcesInformation> _resourcesInformation = new List<ResourcesInformation>()
        {
            FoodExtraction,
            PassageDifficulty,
            ProtectionBonus,
            ProtectionDecline,
            SurveyRangeBonus,
            ShotRangeBonus,
            OreQuantity
        };
        return _resourcesInformation;
    }

    public virtual List<TextInformation> GetTextInformation()
    {
        List<TextInformation> _textInformation = new List<TextInformation>()
        {
            Name,
        };
        return _textInformation;
    }

}



public class IceCell : CellState
{
    public IceCell()
    {
        SetInformation();
    }

    private  void SetInformation()
    {
        Name = new TextInformation("Name", "Ice");
        FoodExtraction = new ResourcesInformation("FoodExtraction", -1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 2);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 0);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -2);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 0);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 0);
        OreQuantity = new ResourcesInformation("OreQuantity", 0);


    }
  
}

public class OceanCell : CellState
{
    public OceanCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Ocean");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 0);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 5);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 0);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", 0);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 0);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 0);
        OreQuantity = new ResourcesInformation("OreQuantity", 0);


    }

}

public class WaterCell : CellState
{
    public WaterCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Water");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 2);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 0);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", 0);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", -1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", -1);
        OreQuantity = new ResourcesInformation("OreQuantity", 0);


    }

}

public class TundraCell : CellState
{
    public TundraCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Tundra");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 1);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 0);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", 0);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 0);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 0);
        OreQuantity = new ResourcesInformation("OreQuantity", 1);


    }

}

public class SteppeCell : CellState
{
    public SteppeCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Steppe");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 1);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 1);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -1);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 1);
        OreQuantity = new ResourcesInformation("OreQuantity", 1);


    }

}

public class ForestCell : CellState
{
    public ForestCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Forest");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 2);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 2);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 1);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -1);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", -1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", -1);
        OreQuantity = new ResourcesInformation("OreQuantity", 2);


    }
}

public class UndergrowthCell : CellState
{
    public UndergrowthCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Undergrowth");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 1);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 1);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -1);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 0);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 0);
        OreQuantity = new ResourcesInformation("OreQuantity", 1);


    }
}

public class PlainCell : CellState
{
    public PlainCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Plain");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 3);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 1);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 1);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", 0);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 1);
        OreQuantity = new ResourcesInformation("OreQuantity", 1);


    }
}

public class SwampCell : CellState
{
    public SwampCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Swamp");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 2);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 2);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -2);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", -1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", -1);
        OreQuantity = new ResourcesInformation("OreQuantity", 0);


    }
}

public class JungleCell : CellState
{
    public JungleCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Jungle");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 2);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 2);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 2);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -2);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", -2);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", -1);
        OreQuantity = new ResourcesInformation("OreQuantity", 2);


    }
}

public class SandCell : CellState
{
    public SandCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Sand");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 0);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 1);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 0);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", 0);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 0);
        OreQuantity = new ResourcesInformation("OreQuantity", 0);


    }
}

public class DesertCell : CellState
{
    public DesertCell()
    {
        SetInformation();
    }


    private void SetInformation()
    {
        Name = new TextInformation("Name", "Desert");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 2);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 0);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -2);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", -1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 0);
        OreQuantity = new ResourcesInformation("OreQuantity", 1);


    }
}

public class SavannahCell : CellState
{
    public SavannahCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Savannah");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 2);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 2);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 0);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", 0);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", -1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 0);
        OreQuantity = new ResourcesInformation("OreQuantity", 1);


    }
}

public class DuneCell : CellState
{
    public DuneCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Dune");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 0);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 3);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 1);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -1);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 1);
        OreQuantity = new ResourcesInformation("OreQuantity", 0);


    }
}

public class HillsCell : CellState
{
    public HillsCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Hills");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 3);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 2);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", 1);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 1);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 1);
        OreQuantity = new ResourcesInformation("OreQuantity", 3);


    }
}

public class DesertMountainsCell : CellState
{
    public DesertMountainsCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "DesertMountains");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 0);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 4);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 4);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -2);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 3);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 2);
        OreQuantity = new ResourcesInformation("OreQuantity", 5);


    }
}

public class MountainCell : CellState
{
    public MountainCell()
    {
        SetInformation();
    }

    private void SetInformation()
    {
        Name = new TextInformation("Name", "Mountain");
        FoodExtraction = new ResourcesInformation("FoodExtraction", 1);
        PassageDifficulty = new ResourcesInformation("PassageDifficulty", 4);
        ProtectionBonus = new ResourcesInformation("ProtectionBonus", 4);
        ProtectionDecline = new ResourcesInformation("ProtectionDecline", -2);
        SurveyRangeBonus = new ResourcesInformation("SurveyRangeBonus", 3);
        ShotRangeBonus = new ResourcesInformation("ShotRangeBonus", 2);
        OreQuantity = new ResourcesInformation("OreQuantity", 5);


    }
}
