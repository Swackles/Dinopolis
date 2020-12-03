using UnityEngine;
using UnityEngine.EventSystems;
using Mastermind.Input;

namespace Mastermind.Inventory
{
    public class Item : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Canvas Canvas;
        private CanvasGroup CanvasGroup;
        private RectTransform RectTransform;
        private Vector2 StartPos;
        public Field InputField; // Use this to refrence to a slot element is in

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            Canvas = GetComponentInParent<Canvas>();
            CanvasGroup = GetComponent<CanvasGroup>();
            StartPos = RectTransform.anchoredPosition;
            InputField = null;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            CanvasGroup.alpha = .6f;
            CanvasGroup.blocksRaycasts = false;

            GameObject.Find("Click").GetComponent<AudioSource>().Play();

            // When movement starts and binded to an inputSlot, unbind from that slot
            if (InputField != null)
            {
                UnbindFromSlot();
            }

        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransform.anchoredPosition += eventData.delta / Canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            CanvasGroup.alpha = 1f;
            CanvasGroup.blocksRaycasts = true;

            GameObject.Find("Drop").GetComponent<AudioSource>().Play();

            // If InputSlot is set don't return to the original position
            if (InputField == null)
            {
                ReturnToStart();
            }
        }

        /// <summary>
        /// Use this method to return DragDrop object to where it started
        /// </summary>
        private void ReturnToStart()
        {
            RectTransform.anchoredPosition = StartPos;
        }

        /// <summary>
        /// Unbind element from InputSlot
        /// </summary>
        private void UnbindFromSlot()
        {
            InputField.Value = null;
            InputField = null;
        }
    }
}
