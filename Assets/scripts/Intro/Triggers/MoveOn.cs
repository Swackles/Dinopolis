using UnityEngine;
using System.Collections;
using Triggers;
using Triggers.Children;

namespace Intro.Triggers
{
    class MoveOn : TextBox, IChild
    {
        [SerializeField]
        GameObject Button = null;
        [SerializeField]
        GameObject NewPosition = null;
        GameObject OriginalButton = null;

        new public void StartUp()
        {
            base.StartUp();
            OriginalButton = GetComponentsInParent<Container>()[0].Button;
            Button.SetActive(false);
        }

        new public void Action()
        {
            base.Action();
            Container container = GetComponentsInParent<Container>()[0];
            container.gameObject.transform.position =  NewPosition.transform.position;
            container.Button = Button;
        }

        new public void AfterAction()
        {
            base.AfterAction();
            GetComponentsInParent<Container>()[0].Button = OriginalButton;
        }
    }
}
