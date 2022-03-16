using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform[] enemiesFields;
    [SerializeField] private Slider sliderProgressLevel;

    public void UpdateSlider()
    {
        int countEnemies = 0;
        foreach (Transform field in enemiesFields)
        {
            countEnemies += field.childCount;
        }
        sliderProgressLevel.value = sliderProgressLevel.maxValue - countEnemies;
    }
}