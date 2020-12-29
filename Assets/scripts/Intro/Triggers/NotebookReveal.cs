using UnityEngine;
using Triggers;
using Triggers.Children;

namespace Intro.Triggers
{
    class NotebookReveal : TextBox, IChild
    {
        [SerializeField]
        GameObject Arrow = null;
        [SerializeField]
        GameObject Notebook = null;

        new public void StartUp()
        {
            base.StartUp();
            Arrow.SetActive(false);
            Notebook.SetActive(false);
        }

        new public void Action()
        {
            base.Action();
            Arrow.SetActive(true);
            Notebook.SetActive(true);
        }

        new public void AfterAction()
        {
            base.AfterAction();
            Arrow.SetActive(false);
        }
    }

}
