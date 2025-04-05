using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundCheckpoints : MonoBehaviour
{
    public float day1EndDistance;
    public float day2EndDistance;
    public float day3EndDistance;

    public bool day1Passed;
    public bool day2Passed;
    public bool day3Passed;

    public UnityEvent day1Event;
    public UnityEvent day2Event;
    public UnityEvent day3Event;

    private void Update()
    {
        if (transform.position.y >= day1EndDistance && day1Passed != true)
        {
            day1Passed = true;
            day1Event.Invoke();
        }
     else if (transform.position.y >= day2EndDistance && day2Passed != true)
        {
            day2Passed = true;
            day2Event.Invoke();
        }
     else if (transform.position.y >= day3EndDistance && day3Passed != true)
        {
            day3Passed = true;
            day3Event.Invoke();
        }
    }
}
