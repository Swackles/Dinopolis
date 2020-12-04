using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using QFSW.QC;


[CommandPrefix("TextContainer.")]
class TextContainer : MonoBehaviour
{
    GameObject[] TextBoxes;
    int Active = 0;
    [SerializeField]
    Image MoveOn;
    [SerializeField]
    Image LetsGo;
    [SerializeField]
    Vector2 NewPosition;

    private void Awake()
    {
        MoveOn.color = new Color(1, 1, 1, 0);
        LetsGo.color = new Color(1, 1, 1, 0);

        SetAlpha(0);

        TextBoxes = GetComponentsInChildren<Text>().Select(x => x.gameObject).ToArray();
        for (int i = 1; i < TextBoxes.Length; i++)
        {
            TextBoxes[i].SetActive(false);
        }

        System.Threading.Thread.Sleep(2000);
        StartCoroutine(Fade(false));
    }

    private IEnumerator Fade(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                SetAlpha(i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                SetAlpha(i);
                yield return null;
            }
        }
    }

    [Command]
    public void SetAlpha(float value)
    {
        this.GetComponent<Image>().color = new Color(1, 1, 1, value);
        this.GetComponent<CanvasGroup>().alpha = value;
    }

    public void Next()
    {

        if (Active < TextBoxes.Length - 1)
        {
            TextBoxes[Active].SetActive(false);
            Active++;
            TextBoxes[Active].SetActive(true);

            switch(Active)
            {
                case 4:
                    this.GetComponentInChildren<Button>().gameObject.SetActive(false);

                    StartCoroutine(Wait());
                    StartCoroutine(FadeIn(LetsGo));
                    break;
                case 5:
                    transform.localPosition = NewPosition;

                    LetsGo.color = new Color(1, 1, 1, 0);

                    StartCoroutine(Wait());
                    StartCoroutine(FadeIn(MoveOn));
                    break;
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

    private IEnumerator FadeIn(Image image)
    {

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
