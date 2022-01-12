using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    GameObject vfxParent;
    const string VFX_PARENT_NAME = "VFX";

    private void Start()
    {
        CreateVFXParent();
    }

    private void CreateVFXParent()
    {
        vfxParent = GameObject.Find(VFX_PARENT_NAME);
        if (!vfxParent)
            vfxParent = new GameObject(VFX_PARENT_NAME);
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
        else if (health <= 100f && GetComponent<Mage>())
        {
            GetComponent<Animator>().SetInteger("stage", 2);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate
            (deathVFX, 
            transform.position, 
            transform.rotation);
        deathVFXObject.transform.parent = vfxParent.transform;
        Destroy(deathVFXObject, 1f);
    }

    public float GetHealth()
    {
        return health;
    }
}
