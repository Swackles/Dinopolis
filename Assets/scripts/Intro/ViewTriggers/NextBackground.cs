using UnityEngine;

namespace Intro.ViewTriggers
{
    class NextBackground : MonoBehaviour
    {
        [SerializeField]
        BackgroundContainer BackgroundContainer;

        private void OnEnable()
        {
            BackgroundContainer.Next();
        }
    }
}

