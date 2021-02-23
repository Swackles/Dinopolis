using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Notebook;

namespace Triggers.Children
{
    class AwaitNotebookPageClose : MonoBehaviour, IChild
    {
        private bool activated = false;
        [SerializeField]
        int Page = 0;

        public void StartUp()
        {
        }

        public void Action()
        {
            transform.parent.localScale = new Vector3(0, 0, 0);
            StartCoroutine(WaitForFinish());
        }

        public void AfterAction()
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
        }

        public bool Finished()
        {
            return GameObject.Find("Notebook").GetComponent<NotebookContainer>().LastPage == Page;
        }

        private IEnumerator WaitForFinish()
        {
            while (!Finished())
                yield return new WaitForSeconds(0.1f);

            yield return new WaitForSeconds(2f);
            GetComponentInParent<Container>().Next();
        }
    }
}
