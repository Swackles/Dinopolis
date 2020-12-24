using UnityEngine;

namespace TextContainer
{
    class Child : MonoBehaviour
    {
        public int ID { get; set; }
        public TypeWriter TypeWriter { get; set; }
        public Triggers.Generic Trigger { get; set; }

        public void Awake()
        {
            TypeWriter = GetComponent<TypeWriter>();
            Trigger = GetComponent<Triggers.Generic>();
        }

        public void enable()
        {
            Trigger?.Run();
            if (TypeWriter != null)
            {
                TypeWriter.gameObject.SetActive(true);
            }
        }
        public void disable()
        {
            if (TypeWriter != null)
            {
                TypeWriter.gameObject.SetActive(false);
            }
        }
    }

}