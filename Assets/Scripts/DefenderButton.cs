using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    ButtonSoundPlayer buttonSound;
    private void Start()
    {
        buttonSound = FindObjectOfType<ButtonSoundPlayer>();
        LabelButtonWithCost();
        SelectDefenderWithKeyboard();
    }

    private void SelectDefenderWithKeyboard()
    {
        switch (defenderPrefab.name)
        {
            case "Disciple":
                StartCoroutine(SelectDisciple());
                break;
            case "Trophy":
                StartCoroutine(SelectTrophy());
                break;
            case "Coffin":
                StartCoroutine(SelectCoffin());
                break;
            case "Master":
                StartCoroutine(SelectMaster());
                break;
        }
    }

    IEnumerator SelectDisciple()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                buttonSound.PlaySound(1);
                SelectDefender();
            }  
            yield return null;
        }
    }

    IEnumerator SelectTrophy()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                buttonSound.PlaySound(1);
                SelectDefender();
            }
            yield return null;
        }
    }
    IEnumerator SelectCoffin()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                buttonSound.PlaySound(1);
                SelectDefender();
            }
            yield return null;
        }
    }
    IEnumerator SelectMaster()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                buttonSound.PlaySound(1);
                SelectDefender();
            }
            yield return null;
        }
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
            Debug.LogError($"{name} has no cost text, add some!");
        else
            costText.text = defenderPrefab.GetEssenceCost().ToString();
    }

    private void OnMouseDown()
    {
        SelectDefender();
    }

    private void SelectDefender()
    {
        buttonSound.PlaySound(1);
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(96, 96, 96, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        if (defenderPrefab)
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
