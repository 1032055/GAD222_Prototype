using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private float visibleFor, fadeOutRate;
    [SerializeField] private SpriteRenderer rendyBoi;

    float percentage;
    int i;

    private void OnEnable()
    {
        //set opacity 100%
        percentage = 1f;
        rendyBoi.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        i = 0;

        //start fade out
        StartCoroutine(FadeImgOut());
    }

    IEnumerator FadeImgOut()
    {
        //let it be visible for a bit
        yield return new WaitForSeconds(visibleFor);

        //fade the thing out 
        while (percentage >= 0f)
        {
            rendyBoi.material.color = new Color(1.0f, 1.0f, 1.0f, percentage);
            percentage -= fadeOutRate;
            i++;
            //Debug.Log("Loop no: " + i);
            yield return null;
        }

        if(percentage <= 0f)
        {
            this.gameObject.SetActive(false);
        }
    }

}
