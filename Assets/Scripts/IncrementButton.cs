using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementButton : MonoBehaviour
{
    public Text numberTextComponent;

    private int currentNumber;

    private void Start()
    {
        // retrieve stored value
        SaveData data = SaveData.Load("save.json");
        currentNumber = data.points;

        UpdateNumberUI();
    }

    private void OnApplicationQuit()
    {
        SaveData data = new SaveData();
        data.points = currentNumber;
        data.Save("save.json");
    }

    private void UpdateNumberUI()
    {
        numberTextComponent.text = currentNumber.ToString();
    }

    public void IncrementNumber()
    {
        currentNumber++;
        UpdateNumberUI();
    }
}
