using UnityEngine;
using UnityEngine.UI;

class NotebookReveal : MonoBehaviour
{
    [SerializeField]
    Image Arrow;
    [SerializeField]
    Image Notebook;
    private void Awake() {
        Notebook.color = new Color(1, 1, 1, 0);
    }

    private void OnEnable()
    {
        Arrow.color = new Color(1, 1, 1, 1);
        Notebook.color = new Color(1, 1, 1, 1);
    }

    private void OnDisable()
    {
        Arrow.color = new Color(1, 1, 1, 0);
    }
}
