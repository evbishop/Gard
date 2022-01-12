using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject gun;
    [SerializeField] int type;
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    int shotNumber = 0;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetSoundVolume()/2;
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
    }

    private void Update()
    {
        switch (type)
        {
            case 1:
                if (IsAttackerInLane())
                    animator.SetBool("isAttacking", true);
                else
                    animator.SetBool("isAttacking", false);
                break;
            default:
                break;
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y)
                <= 0.5f);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public void Fire()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        Projectile shot = Instantiate
            (projectile,
            gun.transform.position,
            transform.rotation);
        shot.transform.parent = projectileParent.transform;
        switch (shotNumber)
        {
            case 0:
                shot.SetShotDirection(0);
                shotNumber++;
                break;
            case 1:
                shot.SetShotDirection(1);
                shotNumber--;
                break;
        }
    }
}
