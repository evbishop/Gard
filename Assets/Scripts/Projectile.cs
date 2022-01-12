using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int projectileType = 1;
    [SerializeField] float startingSpeed = 1f, speed = 10f;
    [SerializeField] float damage = 100f;
    Vector3 startingPos, centerPos;
    bool reachedCenter = false;
    float movementThisFrame = 0f;
    int shotDirection = 0;
    
    void Start()
    {
        startingPos = transform.position;
        centerPos = startingPos + new Vector3(0.2f, -0.3f);
        reachedCenter = false;
        movementThisFrame = startingSpeed * Time.deltaTime;
        switch (projectileType)
        {
            case 1:
                StartCoroutine(MoveType1());
                break;
            case 2:
                StartCoroutine(MoveType2());
                break;
        }
    }

    IEnumerator MoveType1()
    {
        while (true)
        {
            if (!reachedCenter && (transform.position != centerPos))
            {
                transform.position = Vector2.MoveTowards
                    (transform.position, centerPos, movementThisFrame);
            }
            else
            {
                reachedCenter = true;
                movementThisFrame = speed * Time.deltaTime;
                switch (shotDirection)
                {
                    case 0:
                        transform.Translate(Vector2.up * movementThisFrame);
                        break;
                    case 1:
                        transform.Translate(Vector2.down * movementThisFrame);
                        break;
                }
                transform.Translate(Vector2.right * 2f * movementThisFrame);
            }
            yield return null;
        }
    }

    IEnumerator MoveType2()
    {
        while (true)
        {
            if (!reachedCenter && (transform.position != centerPos))
            {
                transform.position = Vector2.MoveTowards
                    (transform.position, centerPos, movementThisFrame);
            }
            else
            {
                reachedCenter = true;
                movementThisFrame = speed * Time.deltaTime;
                transform.Translate(Vector2.right * movementThisFrame);
            }
            yield return null;
        }
    }

    public void SetShotDirection(int directionNumber)
    {
        shotDirection = directionNumber;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
