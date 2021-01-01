using System.Collections;
using UnityEngine;
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
            StartCoroutine(WaitForFinish());
        }

        public void AfterAction()
        {

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
