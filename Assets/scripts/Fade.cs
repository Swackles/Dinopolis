using UnityEngine;
using UnityEngine.UI;
using System.Collections;


class Fade : MonoBehaviour
{
    public IEnumerator Show()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            SetAlpha(i);
            yield return null;
        }
    }

    public IEnumerator Hide()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            SetAlpha(i);
            yield return null;
        }

    }


    public void SetAlpha(float value)
    {
        Image img = GetComponent<Image>();
        if (img != null)
        {
            img.color = new Color(1, 1, 1, value);
        }

        CanvasGroup canvas = GetComponent<CanvasGroup>();
        if (canvas != null)
        {
            canvas.alpha = value;
        }
    }
}
