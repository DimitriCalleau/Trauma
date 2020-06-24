using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour
{
    CanvasGroup textIntegre;
    public float fadingDuration = 0.4f;
    public float timeBeforeFade = 4;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Fading();
        }
    }

    public void Fading()
    {
        textIntegre = GetComponent<CanvasGroup>();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float counter = 0f;

        while (counter < fadingDuration)
        {
            counter += Time.deltaTime;
            textIntegre.alpha = Mathf.Lerp(textIntegre.alpha, 0,  counter / fadingDuration);
            yield return null;
        }

        if(counter > fadingDuration)
        {
            this.gameObject.SetActive(false);
        }
    }

}
