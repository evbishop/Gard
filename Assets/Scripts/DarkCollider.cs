using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<DarkDisplay>().AddDark
            (collision.GetComponent<Attacker>().GetDark());
        Destroy(collision.gameObject);
    }
}
