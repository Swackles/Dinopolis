using UnityEngine;

namespace Triggers
{
    class Container : MonoBehaviour
    {
        public int Active = -1;
        public IChild[] Children;

        private void Awake()
        {
            Children = this.GetComponentsInChildren<IChild>();

            foreach (var child in Children)
            {
                child.StartUp();
            }

            Next();
        }

        public void Next()
        {
            if (Active != -1)
                Children[Active]?.AfterAction();

            Active++;
            Children[Active]?.Action();
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0) && Children[Active].Finished())
                Next();
        }
    }
}
