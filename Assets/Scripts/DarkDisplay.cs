using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkDisplay : MonoBehaviour
{
    [SerializeField] int maxDark = 5;
    int dark;
    Text darkText;

    void Start()
    {
        darkText = GetComponent<Text>();
        dark = maxDark - PlayerPrefsController.GetDifficulty();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        darkText.text = dark.ToString();
    }

    public int GetDark()
    {
        return dark;
    }

    public void AddDark(int amount)
    {
        dark -= amount;
        UpdateDisplay();
        if (dark <= 0)
            FindObjectOfType<LevelController>().
                HandleLoseCondition();
    }
}
