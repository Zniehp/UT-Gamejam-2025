using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{
    public float maxSpeed;

    [SerializeField]
    private float slowDownSpeed;
    [SerializeField]
    private float speedChangeSpeed;
    
    private Rigidbody2D rigidbody2d;
    public float currentSpeed;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }

    private IEnumerator StartMoving()
    {
        while (currentSpeed < maxSpeed)
        {
            currentSpeed += speedChangeSpeed * Time.deltaTime;
            yield return null;
        }
        currentSpeed = maxSpeed;
        yield break;
    }

    private IEnumerator StopMoving()
    {
        while (currentSpeed > slowDownSpeed)
        {
            currentSpeed -= speedChangeSpeed * Time.deltaTime;
            yield return null;
        }
        currentSpeed = slowDownSpeed;
        yield break;
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + currentSpeed * Time.deltaTime);
    }

    public void StartMovingRoutine()
    {
        StartCoroutine(StartMoving());
    }

    public void StartStopRoutine()
    {
        StartCoroutine(StopMoving());
    }
}
