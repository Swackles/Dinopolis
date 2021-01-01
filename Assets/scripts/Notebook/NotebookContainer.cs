using UnityEngine;
using System.Collections;
using System.Linq;

namespace Notebook
{
    class NotebookContainer : MonoBehaviour
    {
        [SerializeField]
        GameObject Background = null;
        [SerializeField]
        public GameObject Center = null;
        [SerializeField]
        public GameObject Submit = null;

        public void ShowHide()
        {
            Background.SetActive(!Background.activeSelf);
        }

        public void CloseHighlighted()
        {
            Note Highlighted = GetComponentsInChildren<Note>().FirstOrDefault(x => { return x.Highlighted; });

            Highlighted.Shrink();
            Submit.SetActive(false);
        }
    }
}
