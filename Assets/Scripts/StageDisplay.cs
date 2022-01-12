using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageDisplay : MonoBehaviour
{
    int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex - 1;
        GetComponent<Text>().text = IntToRoman(currentScene);
    }
    string IntToRoman(int value)
    {
        int[] arabic = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] roman = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        int i;
        string result = "";
        for (i = 0; i < 13; i++)
        {
            while (value >= arabic[i])
            {
                result += roman[i].ToString();
                value -= arabic[i];
            }
        }
        return result;
    }
}
