using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Valve2DRotator : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 lastMouseDirection;
    private float totalRotation = 0f;
    public float requiredRotation = 360f;
    public float valvetimer;
    Vector3 originalPos;


    public UnityEvent OnFail;

    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
        void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            if (Vector2.Distance(transform.position, mouseWorldPos) < 1.5f)
            {
                isDragging = true;
                lastMouseDirection = (mouseWorldPos - transform.position).normalized;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            gameObject.transform.position = originalPos;

            Vector3 currentMouseDirection = (mouseWorldPos - transform.position).normalized;

            float angleDiff = Vector3.SignedAngle(lastMouseDirection, currentMouseDirection, Vector3.forward);
            if (angleDiff < -0)
            {
                transform.Rotate(0f, 0f, angleDiff);
                totalRotation -= angleDiff;

                if (totalRotation >= requiredRotation)
                {
                    Debug.Log("Valve fully turned!");
                    isDragging = false;
                }


                lastMouseDirection = currentMouseDirection;
            }
        }
    }

    public IEnumerator valveTimer()
    {
        yield return new WaitForSeconds(valvetimer);
        if (totalRotation != 360)
        {
            OnFail.Invoke();
        }
        else
        {
            yield break;
        }
    }
}

    


