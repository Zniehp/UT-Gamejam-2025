using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using static UnityEditor.Rendering.ShadowCascadeGUI;

public class DayNightTransition : MonoBehaviour
{
    private Image image;
    private bool IntoDark;
    private Color alphaColor;
    private bool transitionDone;
    private bool canFade;
    private float fadetime;


    public UnityEvent FadeEnd;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Start()
    {
        canFade = false;
        alphaColor = image.color;
        alphaColor.a = 0;
        fadetime = 0;
    }
    public void Update()
    {
        if (canFade)
        {
            image.color = Color.Lerp(image.color, alphaColor, 2 * Time.deltaTime);
            fadetime += Time.deltaTime;
            if (fadetime > 2)
            {
                FadeEnd.Invoke();
            }
        }
    }

    public void StartDeath()
    {
        canFade = true;
    }
}
