using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Triggers.Children
{
    class AutomaticNextTextBox : TextBox, IChild
    {
        new public void Action()
        {
            base.Action();

            StartCoroutine(WaitForFinish());
        }

        private IEnumerator WaitForFinish()
        {
            while (!this.Finished())
                yield return new WaitForSeconds(0.1f);

            yield return new WaitForSeconds(2f);
            GetComponentInParent<Container>().Next();
        }
    }
}
