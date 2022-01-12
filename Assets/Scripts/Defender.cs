using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int essenceCost = 100;

    public void AddEssence(int amount)
    {
        FindObjectOfType<EssenceDisplay>().AddEssence(amount);
    }

    public int GetEssenceCost()
    {
        return essenceCost;
    }
}
