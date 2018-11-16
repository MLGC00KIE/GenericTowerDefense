using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    [SerializeField]
    private Text LiveText;

    private int LiveValue = 50;

    public void SetLives(int amount)
    {
        LiveValue = amount;
    }

    public int GetLives()
    {
        return LiveValue;
    }

    private void Update()
    {
        if (LiveValue <= 0)
        {
            Application.Quit();
        }

        LiveText.text = "Lives: " + LiveValue.ToString();
    }

    public void AddLives(int amount)
    {
        LiveValue += amount;
    }
}

