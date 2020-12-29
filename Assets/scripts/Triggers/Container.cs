using UnityEngine;
using System.Collections;
using QFSW.QC;

namespace Triggers
{

    [CommandPrefix("Container.")]
    class Container : MonoBehaviour
    {
        public int Active = -1;
        public IChild[] Children;
        [SerializeField]
        public bool UseButton = false;
        [SerializeField]
        public GameObject Button = null;

        private void Awake()
        {
            Children = this.GetComponentsInChildren<IChild>();

            foreach (var child in Children)
            {
                child.StartUp();
            }

            Next();
        }

        [Command]
        [CommandDescription("Next item in the triggers container")]
        public void Next()
        {
            if (UseButton)
                Button.SetActive(false);

            if (Active != -1)
                Children[Active].AfterAction();

            Active++;
            Children[Active].Action();

            StartCoroutine(WaitToFinish());
        }

        public IEnumerator WaitToFinish()
        {
            while (!Children[Active].Finished())
                yield return new WaitForSeconds(0.1f);


            Button.SetActive(true);
        }

        public void Update()
        {
            if (!UseButton && Input.GetMouseButtonDown(0) && Children[Active].Finished())
                Next();
        }
    }
}
