using System;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject airMinigame;
    public GameObject oilMinigame;
    public GameObject wheelminigame;

    [SerializeField]
    private float baseMinigameDelay;
    private float currentMinigameDelay;
    public float difficulty;

    private void Start()
    {
        currentMinigameDelay = baseMinigameDelay;
    }
    private void Update()
    {
        currentMinigameDelay -= Time.deltaTime;
    }
    private void StartProblem()
    {
        if (currentMinigameDelay < 0)
        {
            int random = UnityEngine.Random.Range(0, 2);
            switch (random)
            {
                case 0:
                     //also check if game is on already
                    //start air
                    currentMinigameDelay = baseMinigameDelay/difficulty + UnityEngine.Random.Range(0, 3);
                    break;
                case 1:
                    //start oil
                    currentMinigameDelay = baseMinigameDelay / difficulty + UnityEngine.Random.Range(0, 3);
                    break;
                case 2:
                    //start wheel
                    currentMinigameDelay = baseMinigameDelay / difficulty + UnityEngine.Random.Range(0, 3);
                    break;
            }
        }
    }
}
