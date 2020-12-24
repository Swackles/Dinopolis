using UnityEngine;

namespace TextContainer
{
    class Parent : MonoBehaviour
    {
        Child[] Children;
        int activeTypeWriterIndex = 0;

        private void Awake()
        {
            Children = this.GetComponentsInChildren<Child>();

            foreach (Child child in Children)
            {
                child.disable();
            }

            Next(true);
        }

        public void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Next();
            }
        }

        public void Next(bool inital = false)
        {
            bool LoadedText = false;

            while (!LoadedText)
            {
                if (!inital)
                {
                    Children[activeTypeWriterIndex].disable();

                    activeTypeWriterIndex++;
                    inital = false;
                }

                Children[activeTypeWriterIndex].enable();
                LoadedText = Children[activeTypeWriterIndex].TypeWriter == null;
            }
        }
    }
}
