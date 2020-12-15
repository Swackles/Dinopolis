using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    public GameObject Submit;

    private void Awake()
    {
        MoveOn.color = new Color(1, 1, 1, 0);
        LetsGo.color = new Color(1, 1, 1, 0);

        GetComponent<Fade>().SetAlpha(0);

        TextBoxes = GetComponentsInChildren<Text>().Select(x => x.gameObject).ToArray();
        for (int i = 1; i < TextBoxes.Length; i++)
        {
            NotebookReveal nr = TextBoxes[i].GetComponent<NotebookReveal>();
            if (nr != null)
            {
                nr.Disable();
            }
            TextBoxes[i].SetActive(false);
        }

        System.Threading.Thread.Sleep(2000);
        StartCoroutine(GetComponent<Fade>().Show());
    }

    public void Next()
    {

        if (Active < TextBoxes.Length - 1)
        {
            TextBoxes[Active].SetActive(false);
            Active++;
            TextBoxes[Active].SetActive(true);
            Debug.Log(Active);
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
        } else
        {
            SceneManager.LoadScene(1);

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
