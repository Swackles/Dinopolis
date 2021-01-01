using System.Collections;
using UnityEngine;
using Notebook;

namespace Triggers.Children
{
    class AwaitNotebookReveal : TextBox, IChild
    {
        new public void Action()
        {
            base.Action();
            StartCoroutine(WaitForFinish());
        }

        new public bool Finished()
        {
            return base.Finished() && GameObject.Find("Notebook").GetComponent<NotebookContainer>().Background.activeSelf;
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
