using UnityEngine;
using UnityEngine.UI;

class NotebookReveal : MonoBehaviour
{
    [SerializeField]
    Image Arrow;
    [SerializeField]
    Image Notebook;
    bool initialized = false;


    private void OnEnable()
    {
        Arrow.color = new Color(1, 1, 1, 1);
        Notebook.color = new Color(1, 1, 1, 1);
    }

    private void OnDisable()
    {
        Arrow.color = new Color(1, 1, 1, 0);
    }

    public void Disable()
    {
        Notebook.color = new Color(1, 1, 1, 0);
        Arrow.color = new Color(1, 1, 1, 0);

    }
}
