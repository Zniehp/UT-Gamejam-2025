using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using static UnityEditor.Rendering.ShadowCascadeGUI;

public class DayNightTransition : MonoBehaviour
{
    private Image image;
    private bool IntoDark;
    private float alpha;
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
        fadetime = 0;
    }
    public void Update()
    {
        if (canFade)
        {
            Color newcolor = new (image.color.r, image.color.g, image.color.b, image.color.a + (1f * Time.deltaTime));
            image.color = newcolor;
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
