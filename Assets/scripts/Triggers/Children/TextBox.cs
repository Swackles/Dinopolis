using System;
using UnityEngine;
using System.Collections;

namespace Triggers.Children
{
    class TextBox : MonoBehaviour, IChild
    {
        public void StartUp()
        {
            gameObject.SetActive(false);
        }

        public void Action()
        {
            gameObject.SetActive(true);
            StartCoroutine(GetComponent<TypeWriter>().Show());
        }

        public void AfterAction()
        {
            gameObject.SetActive(false);
        }

        public bool Finished()
        {
            return GetComponent<TypeWriter>().finished;
        }
    }
}
