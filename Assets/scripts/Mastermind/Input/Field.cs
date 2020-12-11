using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mastermind.Input
{
    public class Field : MonoBehaviour, IDropHandler
    {
        public GameObject Binded = null;
        public int? Value = null;



        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                if (Value != null) // When I have to switch items between
                {
                    Inventory.Item OldItem = Binded.GetComponent<Inventory.Item>();
                    Inventory.Item NewItem = eventData.pointerDrag.GetComponent<Inventory.Item>();
                    Debug.Log(NewItem.InputField);
                    Debug.Log(OldItem.InputField);
                    if (NewItem.InputField == null) // If new Item came from inventory
                    {
                        OldItem.ReturnToStart();
                    }
                    else
                    {
                        NewItem.InputField.SetValue(OldItem.gameObject);
                    }
                }

                SetValue(eventData.pointerDrag);

            }  
        }

        public  void SetValue(GameObject Binded)
        {
            Binded.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            Binded.GetComponent<Inventory.Item>().InputField = this;

            this.Binded = Binded;
            Value = int.Parse(Binded.name);
        }
    }

}
