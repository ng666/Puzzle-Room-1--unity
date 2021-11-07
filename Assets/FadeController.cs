using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    //private bool isInTransition;
    //private float transition;
    //private float duration;

    void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(0.0f);
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        fadeIn();
    //    }
    //    else if (Input.GetMouseButtonDown(1))
    //    {
    //        fadeOut();
    //    }
    //}

    void fadeIn()
    {
        fadeImage.CrossFadeAlpha(1, 1, false);
    }

    void fadeOut()
    {
        fadeImage.CrossFadeAlpha(0, 2, false);
    }

    IEnumerator fadeC()
    {
        fadeIn();
        yield return new WaitForSeconds(3.0f);
        fadeOut();
    }

    public void fade()
    {
        StartCoroutine(fadeC());
    }
}
