using UnityEngine;

namespace Triggers.Children
{
    class NextBackground : TextBox, IChild
    {
        [SerializeField]
        BackgroundContainer BackgroundContainer = null;

        new public void Action()
        {
            base.Action();
            BackgroundContainer.Next();
        }
    }
}

