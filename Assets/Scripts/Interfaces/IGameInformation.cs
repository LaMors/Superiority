
public interface IGameInformation<T>
{
    string Name { get; set; }

    T Value { get; set; }

    
}

public class ResourcesInformation : IGameInformation<int>
{
    public string Name { get; set; }

    public int Value { get; set; }

    public ResourcesInformation(string _name, int _resoursValue)
    {
        Name = _name;
        Value = _resoursValue;
    }

}

public class TextInformation : IGameInformation<string>
{
    public string Name { get; set; }

    public string Value { get; set; }

    public TextInformation(string _name, string _textInformation)
    {
        Name = _name;
        Value = _textInformation;
    }

}

