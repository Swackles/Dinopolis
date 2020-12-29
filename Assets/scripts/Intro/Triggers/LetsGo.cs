using UnityEngine;
using System.Collections;
using Triggers;
using Triggers.Children;

namespace Intro.Triggers
{
    class LetsGo : NextBackground, IChild
    {
        [SerializeField]
        GameObject Button = null;
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
            GetComponentsInParent<Container>()[0].Button = Button;
        }

        new public void AfterAction()
        {
            base.AfterAction();
            GetComponentsInParent<Container>()[0].Button = OriginalButton;
        }
    }
}
