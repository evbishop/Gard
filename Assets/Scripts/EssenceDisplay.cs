using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceDisplay : MonoBehaviour
{
    [SerializeField] int essence = 100;
    Text essenceText;

    void Start()
    {
        essenceText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        essenceText.text = essence.ToString();
    }

    public bool HaveEnoughEssence(int amount)
    {
        return essence >= amount;
    }

    public void AddEssence(int amount)
    {
        essence += amount;
        UpdateDisplay();
    }

    public void SpendEssence(int amount)
    {
        if (essence >= amount)
        {
            essence -= amount;
            UpdateDisplay();
        }
    }
}
