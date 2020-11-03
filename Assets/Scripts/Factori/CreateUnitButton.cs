using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnitButton : MonoBehaviour
{
    public string NameUnitBottom { get; private set; }

    private void OnEnable()
    {
        NameUnitBottom = gameObject.name;
    }

    public void OnClic()
    {
        EventCreationObject.SetUnit(NameUnitBottom);
    }
}
