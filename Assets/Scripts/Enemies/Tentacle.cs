using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [Range(0f, 5f)] float currentSpeed = 1f;
    [SerializeField] int dark = 1;
    float pathCenter;
    float xBeforeMove;
    int whichWay = 0;

    private void Start()
    {
        pathCenter = transform.position.y;
        whichWay = Mathf.RoundToInt(Random.Range(0f, 1f));
        StartCoroutine(StartingTentacle());
    }
    
    IEnumerator StartingTentacle()
    {
        xBeforeMove = transform.position.x;
        while ((xBeforeMove - transform.position.x) <= 1f)
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(MoveTentacle());
    }
    
    IEnumerator MoveTentacle()
    {
        StopCoroutine(StartingTentacle());
        while (true)
        {
            xBeforeMove = transform.position.x;
            switch (whichWay)
            {
                case 0:
                    yield return StartCoroutine(MoveUp());
                    whichWay = 1;
                    break;
                case 1:
                    yield return StartCoroutine(MoveDown());
                    whichWay = 0;
                    break;
            }
        }
    }
    
    IEnumerator MoveUp()
    {
        while ((xBeforeMove - transform.position.x) <= 1f)
        {
            transform.Translate(Vector2.left * 2f * currentSpeed * Time.deltaTime);
            transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator MoveDown()
    {
        while ((xBeforeMove - transform.position.x) <= 1f)
        {
            transform.Translate(Vector2.left * 2f * currentSpeed * Time.deltaTime);
            transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

    public int GetDark()
    {
        return dark;
    }
}
