using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    ButtonSoundPlayer buttonSoundPlayer;

    private void Start()
    {
        buttonSoundPlayer = FindObjectOfType<ButtonSoundPlayer>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetHexagonClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var EssenceDisplay = FindObjectOfType<EssenceDisplay>();
        if (defender)
        {
            int defenderCost = defender.GetEssenceCost();
            if (EssenceDisplay.HaveEnoughEssence(defenderCost))
            {
                SpawnDefender(gridPos);
                EssenceDisplay.SpendEssence(defenderCost);
            }
        }
    }

    private Vector2 GetHexagonClicked()
    {
        Vector2 clickPos = new Vector2
            (Input.mousePosition.x,
            Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.Round(rawWorldPos.x);
        float newY;
        if (newX % 2 == 1)
            newY = Mathf.Round(rawWorldPos.y);
        else
            newY = Mathf.Floor(rawWorldPos.y) + 0.5f;
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 hex)
    {
        buttonSoundPlayer.PlaySound(0);
        Defender newDefender = Instantiate
            (defender,
            hex,
            Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }
}