using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class O2Minigame : MonoBehaviour
{

    public int counter = 0;
    public Transform imageTransform;

 

    public float maxOxygenTimer;
    public float currentOxygenTimer;
    [SerializeField]
    private float percentOxygen;
    private bool OxygenGameOn;

    public UnityEvent oxygenLose;

    private void Awake()
    {
        StartOxygen();
    }

    private void Update()
    {
        CalculateOxygen();
    }
    public void Getmouseshit()
    {
        Debug.Log("palun");
        counter++;
    }
    public void MoveOxygen()
    {   
        float newYlevel = -2.6f + (0.8f * percentOxygen);
            Vector3 newposition = new(imageTransform.position.x, newYlevel, imageTransform.position.z);
            imageTransform.position = newposition;
    }

    private void CalculateOxygen()
    {
        if (OxygenGameOn)
        {
            currentOxygenTimer -= Time.deltaTime;
            percentOxygen = currentOxygenTimer/maxOxygenTimer;
            MoveOxygen();
            if (currentOxygenTimer < 0)
            {
                oxygenLose.Invoke();
            }
            if (currentOxygenTimer >= maxOxygenTimer)
                if(counter > 5)
                {
                    OxygenGameOn = false;
                }
                else
                {
                    currentOxygenTimer = maxOxygenTimer;
                }
        }
    }

    public void StartOxygen()
    {
        currentOxygenTimer = maxOxygenTimer;
        OxygenGameOn = true;
        counter = 0;
    }
}


