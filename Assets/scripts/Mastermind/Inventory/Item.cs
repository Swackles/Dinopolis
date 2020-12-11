using UnityEngine;
using UnityEngine.EventSystems;
using Mastermind.Input;
using QFSW.QC;

namespace Mastermind.Inventory
{
    public class Item : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        private Canvas Canvas;
        private CanvasGroup CanvasGroup;
        private RectTransform RectTransform;
        private Vector2 StartPos;
        public Field InputField = null; // Use this to refrence to a slot element is in
        public Field InputFieldCache = null;

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            Canvas = GetComponentInParent<Canvas>();
            CanvasGroup = GetComponent<CanvasGroup>();
            StartPos = RectTransform.anchoredPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            InputFieldCache = InputField;

            CanvasGroup.alpha = .6f;
            CanvasGroup.blocksRaycasts = false;

            GameObject.Find("Click").GetComponent<AudioSource>().Play();
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

            if (InputFieldCache == InputField)
            {
                ReturnToStart();
            }
        }

        /**
         * Need to use this, cause when InputField has an object binded to it,
         * dropping another on it will not trigger onDrop on the field cause Item is on top if it
         */
        public void OnDrop(PointerEventData eventData)
        {
            if (InputField != null) {
                InputField.OnDrop(eventData);
            }
        }

        /// <summary>
        /// Use this method to return DragDrop object to where it started
        /// </summary>
        public void ReturnToStart()
        {
            UnbindFromSlot();
            RectTransform.anchoredPosition = StartPos;
        }

        /// <summary>
        /// Unbind element from InputSlot
        /// </summary>
        public void UnbindFromSlot()
        {
            if (InputField == null) { return; }
            InputField.Value = null;
            InputField = null;
        }
    }
}
