using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class NextButtonScript : MonoBehaviour
{
    public TextData[] Day1morning;
    public TextData[] Day2morning;
    public TextData[] Day3morning;
    public TextData[] Day1Night;
    public TextData[] Day2Night;
    public TextData[] Day3Night;
    public BackgroundCheckpoints backgroundCheckpoints;
    public TextDisplay textManager;
    private int currentTextIndex;
    private bool buttonPressed;

    public UnityEvent OnTextEnd;

    public void CheckStoryState()
    {
        if(backgroundCheckpoints.day3Passed)
        {
            currentTextIndex = 0;
            StartCoroutine(StartDay3EndSequence());
        }
        else if (backgroundCheckpoints.day2Passed)
        {
            currentTextIndex = 0;
            StartCoroutine(StartDay2EndSequence());
        }
        else if (backgroundCheckpoints.day1Passed)
        {
            currentTextIndex = 0;
            StartCoroutine(StartDay1EndSequence());
        }
        else
        {
            currentTextIndex = 0;
            StartCoroutine(StartDay1StartSequence());
        }

    }
    private IEnumerator StartDay1EndSequence()
    {
        if (currentTextIndex <= Day1Night.Length)
        {
            textManager.currentText = Day1Night[currentTextIndex];
            textManager.UpdateText();
            currentTextIndex += 1;

            while (buttonPressed == false)
            {
                yield return null;
            }

            buttonPressed = false;
        }
        else if (currentTextIndex <= Day2morning.Length + Day1Night.Length)
        {
            textManager.currentText = Day2morning[currentTextIndex - Day1Night.Length];
            textManager.UpdateText();
            currentTextIndex += 1;

            while (buttonPressed == false)
            {
                yield return null;
            }

            buttonPressed = true;
            yield return null;
        }
        else
        {
            OnTextEnd.Invoke();
            yield break;
        }
    }

    private IEnumerator StartDay2EndSequence()
    {
        while (currentTextIndex <= Day1Night.Length)
        {
            textManager.currentText = Day2Night[currentTextIndex];
            textManager.UpdateText();
            currentTextIndex += 1;

            while (buttonPressed == false)
            {
                yield return null;
            }

            buttonPressed = true;
            yield return null;
        }

        while (currentTextIndex <= Day3morning.Length + Day2Night.Length)
        {
            textManager.currentText = Day2morning[currentTextIndex - Day1Night.Length];
            textManager.UpdateText();
            currentTextIndex += 1;

            while (buttonPressed == false)
            {
                yield return null;
            }

            buttonPressed = true;
            yield return null;
        }
        OnTextEnd.Invoke();
        yield break;

    }

    private IEnumerator StartDay3EndSequence()
    {
        while (currentTextIndex <= Day3Night.Length)
        {
            textManager.currentText = Day1Night[currentTextIndex];
            textManager.UpdateText();
            currentTextIndex += 1;

            while (buttonPressed == false)
            {
                yield return null;
            }

            buttonPressed = true;
            yield return null;
        }

        OnTextEnd.Invoke();
        yield break;
    }

    private IEnumerator StartDay1StartSequence()
    {
        while (currentTextIndex <= Day1morning.Length)
        {
            textManager.currentText = Day1morning[currentTextIndex];
            textManager.UpdateText();
            currentTextIndex += 1;

            while (buttonPressed == false)
            {
                yield return null;
            }

            buttonPressed = true;
            yield return null;
        }

        OnTextEnd.Invoke();
        yield break;
    }

    public void ButtonPressered()
    {
        buttonPressed = true;
    }
}
