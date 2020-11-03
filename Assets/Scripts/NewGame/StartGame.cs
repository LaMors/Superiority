using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class StartGame : MonoBehaviour
{
    public float elevationСustomization = 1f;
    public float temperatureСustomization = -0.5f;
    public float biomeSizeСustomization = 0.5f;
    public int worldSizeHeight = 50;
    public int worldSizeWidth = 50;


    public void SliderElevation(Slider slider)
    {
        elevationСustomization = slider.value;
    }

    public void SliderTemperature(Slider slider)
    {
        temperatureСustomization = slider.value;
    }

    public void SliderBiomeSize(Slider slider)
    {
        biomeSizeСustomization = slider.value;
    }

    public void SliderSize(Slider slider)
    {
        
        worldSizeHeight =  10 * (int)slider.value;
        worldSizeWidth =  10 * (int)slider.value;

    }

    public void ClickStart()
    {
        StartDataHolder.elevelevationHolder = elevationСustomization;

        StartDataHolder.temperatureHolder = temperatureСustomization;

        StartDataHolder.biomeSizeHolder = 5 - biomeSizeСustomization;

        StartDataHolder.worldHeightHolder = worldSizeHeight;

        StartDataHolder.worldWidthHolder = worldSizeHeight;

        SceneManager.LoadScene("Play", LoadSceneMode.Single);

    }
}
