using System;
using UnityEngine;
using UnityEngine.Events;

public class MonsterManagerScript : MonoBehaviour
{
    public float monsterAngerLevel;

    [SerializeField]
    private float startingMonsterAnger;
    [SerializeField]
    private float startingHuntTime;

    public float remainingHuntTime;
    private bool isHunting;
    public float monsterDistance;

    public UnityEvent onDiedToMonster;
    public AudioClip monster1;
    public AudioClip monster2;
    public AudioSource musicSource;
    

    private void Awake()
    {
        musicSource = FindAnyObjectByType<AudioSource>();
        remainingHuntTime = startingHuntTime;
        monsterAngerLevel = startingMonsterAnger;
    }

    private void Update()
    {
        CheckIfHunting();
        Hunt();
    }

    public void ChangeMonsterAnger(float amount)
    {
        monsterAngerLevel += amount*5;

        if (monsterAngerLevel > 100f)
        {
            monsterAngerLevel = 100f;
        }
        else if (monsterAngerLevel < 0f)
        {
            monsterAngerLevel = 0f;
        }
    }

    private void CheckIfHunting()
    {
        if (monsterAngerLevel == 100f)
        {
            isHunting = true;
        }
        else
        {
            isHunting = false;
        }
    }

    private void Hunt()
    {
        if (isHunting)
        {
            remainingHuntTime -= Time.deltaTime;
            CheckHuntState();
        }
    }

    private void CheckHuntState()
    {
        if (remainingHuntTime >= startingHuntTime/8*7)
        {
            monsterDistance = 8;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 6)
        {
            monsterDistance = 7;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 5)
        {
            monsterDistance = 6;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 4)
        {
            monsterDistance = 5;
            if (musicSource.clip != monster1)
            {
                musicSource.clip = monster1;
                musicSource.Play();
            }
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 3)
        {
            monsterDistance = 4;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 2)
        {
            monsterDistance = 3;
        }
        else if (remainingHuntTime >= startingHuntTime / 8)
        {
            monsterDistance = 2;
            if (musicSource.clip != monster2)
            {
                musicSource.clip = monster2;
                musicSource.Play();
            }
        }
        else if (remainingHuntTime < startingHuntTime / 8 && remainingHuntTime > 0f)
        {
            monsterDistance = 1;
        }
        else
        {
            onDiedToMonster.Invoke();
        }
    }
}
