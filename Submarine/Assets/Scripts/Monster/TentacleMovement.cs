using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TentacleMovement : MonoBehaviour
{
    public MonsterManagerScript monsterManagerScript;
    private Vector3 startingPos;

    [SerializeField]
    private Transform centerPoint;
    public Vector3 targetPosition;
    private float monsterDistance;

    private float tentacleSpeed = 0.3f;
    private bool isActive;

    private void Awake()
    {
        startingPos = this.transform.position;
    }

    private void Start()
    {
        StartCoroutine(MonsterMove());
    }

    private void Update()
    {
        monsterDistance = monsterManagerScript.monsterDistance;
    }

    private IEnumerator MonsterMove()
    {
        while (isActive != true)
        {
            //creates a point for the tentacle to move to based on monsterdistance
            targetPosition = new Vector3(startingPos.x / 8 * monsterDistance + centerPoint.position.x,
                startingPos.y / 8 * monsterDistance + centerPoint.position.y, startingPos.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, tentacleSpeed * Time.deltaTime);
            yield return null;
        }
        yield break;
    }
}
