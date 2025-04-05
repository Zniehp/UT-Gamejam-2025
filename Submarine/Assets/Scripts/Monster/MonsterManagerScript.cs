using System;
using UnityEngine;

public class MonsterManagerScript : MonoBehaviour
{
    public float monsterAngerLevel;

    [SerializeField]
    private float startingMonsterAnger;
    [SerializeField]
    private float startingHuntTime;
    [SerializeField]
    private Transform centerPoint;

    private float remainingHuntTime;
    private bool isHunting;
    private float monsterDistance;

    public GameObject monsterGraphics;
    public Animator monsterAnimator;
    

    private void Awake()
    {
        remainingHuntTime = startingHuntTime;
        monsterAngerLevel = startingMonsterAnger;
        monsterAnimator = monsterGraphics.GetComponent<Animator>();
    }

    private void Update()
    {
        CheckIfHunting();
        Hunt();
    }

    public void ChangeMonsterAnger(float amount)
    {
        monsterAngerLevel += amount;

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
            monsterAnimator.SetInteger("HuntStage", 0);
            monsterDistance = 0;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 6)
        {
            monsterAnimator.SetInteger("HuntStage", 1);
            monsterDistance = 1;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 5)
        {
            monsterAnimator.SetInteger("HuntStage", 2);
            monsterDistance = 2;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 4)
        {
            monsterAnimator.SetInteger("HuntStage", 3);
            monsterDistance = 3;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 3)
        {
            monsterAnimator.SetInteger("HuntStage", 4);
            monsterDistance = 4;
        }
        else if (remainingHuntTime >= startingHuntTime / 8 * 2)
        {
            monsterAnimator.SetInteger("HuntStage", 5);
            monsterDistance = 5;
        }
        else if (remainingHuntTime >= startingHuntTime / 8)
        {
            monsterAnimator.SetInteger("HuntStage", 6);
            monsterDistance = 6;
        }
        else if (remainingHuntTime < startingHuntTime / 8 && remainingHuntTime > 0f)
        {
            monsterAnimator.SetInteger("HuntStage", 7);
            monsterDistance = 7;
        }
        else
        {

        }
    }
}
