using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class O2Minigame : MonoBehaviour
    {
    public RectTransform imageToMove;
    public float ChangeAmount = 1.3f;

    public void Getmouseshit()
    {
        if (Input.GetMouseButtonDown(0) {

        }
    }
    public void MoveOxygen()

    {

        Vector3 currentPosition = imageToMove.anchoredPosition;
        currentPosition.y += ChangeAmount;
        imageToMove.anchoredPosition = currentPosition;
    }
}



