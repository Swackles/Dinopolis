using UnityEngine;
using System.Collections;
using System.Linq;

namespace Notebook
{
    class NotebookContainer : MonoBehaviour
    {
        [SerializeField]
        public GameObject Background = null;
        [SerializeField]
        public GameObject Center = null;
        [SerializeField]
        public GameObject Submit = null;
        [SerializeField]
        public int LastActivePage = 0;

        public int Page = -1;
        public int LastPage = -1;
        private Note[] Notes;

        public void Awake()
        {
            Notes = GetComponentsInChildren<Note>();

            for (int i = 0; i < Notes.Length; i++)
            {
                if (i > LastActivePage)
                    Notes[i].gameObject.SetActive(false);
            }
        }

        public void RevealNext()
        {
            foreach (Note note in Notes)
            {
                if (!note.gameObject.activeSelf)
                {
                    note.gameObject.SetActive(true);
                    return;
                }
            }
        }

        public void ShowHide()
        {
            Background.SetActive(!Background.activeSelf);
        }

        public void ActivePage(int page)
        {
            Page = page;
            Submit.SetActive(true);
        }

        public void CloseHighlighted()
        {
            LastPage = Page;
            Page = -1;
            Note Highlighted = GetComponentsInChildren<Note>().FirstOrDefault(x => x.name == LastPage.ToString());

            Highlighted.Shrink();
            Submit.SetActive(false);
        }
    }
}
