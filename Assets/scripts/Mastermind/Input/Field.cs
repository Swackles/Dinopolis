using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mastermind.Input
{
    public class Field : MonoBehaviour, IDropHandler
    {
        public int? Value = null;
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null && Value == null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

                Inventory.Item Script = eventData.pointerDrag.GetComponent<Inventory.Item>();
                Script.InputField = this;
                Value = Int32.Parse(eventData.pointerDrag.gameObject.name);
            }
        }
    }

}
