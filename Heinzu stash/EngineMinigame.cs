using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EngineMinigame : MonoBehaviour
{

    public bool oilBool = false;
    public Transform oilimageTransform;
    public float maxOilTimer;
    public float currentOilTimer;
    [SerializeField]
    private float percentOil;
    private bool OilGameOn;
    public UnityEvent oilLose;

    private void Awake()
    {
        StartOil();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oilBool = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            oilBool = false;
        }
    }

    public void MoveOil()
    {
        float newYlevel = -2.6f + (0.8f * percentOil);
        Vector3 newposition = new(oilimageTransform.position.x, newYlevel, oilimageTransform.position.z);
        oilimageTransform.position = newposition;
    }

    private void CalculateOil()
    {
        if (OilGameOn && oilBool == true)
        {
            currentOilTimer -= Time.deltaTime;
            percentOil = currentOilTimer / maxOilTimer;
            MoveOil();
            if (currentOilTimer < 0)
            {
                oilLose.Invoke();
            }
        
        }
    }

    public void StartOil()
    {
        currentOilTimer = maxOilTimer;
        OilGameOn = true;
    }
}

