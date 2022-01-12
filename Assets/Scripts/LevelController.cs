using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject gameMenu;
    ButtonSoundPlayer buttonSoundPlayer;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        gameMenu.SetActive(false);
        buttonSoundPlayer = FindObjectOfType<ButtonSoundPlayer>();
        //PlayerPrefsController.SetReachedStage(1); //doing this the first time around
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buttonSoundPlayer.PlaySound(1);
            switch (gameMenu.activeInHierarchy)
            {
                case true:
                    GameResume();
                    break;
                case false:
                    GamePause();
                    break;
            }
        }
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if ((numberOfAttackers <= 0) && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        yield return new WaitForSeconds(0.5f);
        if (FindObjectOfType<DarkDisplay>().GetDark() > 0)
        {
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waitToLoad);
            int nextStage = SceneManager.GetActiveScene().buildIndex;
            if (PlayerPrefsController.GetReachedStage() < nextStage)
                PlayerPrefsController.SetReachedStage(nextStage);
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        gameMenu.SetActive(true);
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        gameMenu.SetActive(false);
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
