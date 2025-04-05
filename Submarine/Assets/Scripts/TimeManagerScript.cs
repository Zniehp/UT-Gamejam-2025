using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{
    public void StartTime()
    {
        Time.timeScale = 1.0f;
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
}
