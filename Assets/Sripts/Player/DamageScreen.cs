using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{

    public Image DamageScreenUI;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    public IEnumerator ShowEffect()
    {
        DamageScreenUI.enabled = true;
        for (float t = 1f; t > 0f; t -= Time.deltaTime)
        {
            DamageScreenUI.color = new Color(1, 0, 0, t);
            yield return null;
        }
        DamageScreenUI.enabled = false;
    }

    public void HideImage()
    {
        DamageScreenUI.enabled = false;
    }

}
