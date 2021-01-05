using UnityEngine;
using UnityEngine.EventSystems;
using QFSW.QC;

namespace Notebook
{
    enum MoveState
    {
        Stand,
        Shrink, // Shrink the Note
        Expand // Expand the Note
    }

    [CommandPrefix("Notebook.Note.")]
    class Note : MonoBehaviour, IPointerClickHandler
    {
        Vector3 OriginalPosition;
        Vector3 ExpandedPosition;
        Vector3 OriginalScale;
        Vector3 ExpandedScale;
        float speed = 1000;
        float scaleSpeed = 1000;
        MoveState State = MoveState.Stand;
        public bool Highlighted = false;
        [SerializeField]
        string ActionName = null;

        public void Awake()
        {
            OriginalPosition = transform.position;
            ExpandedPosition = GetComponentInParent<NotebookContainer>().Center.gameObject.transform.position;

            ExpandedPosition.z = 100; // For some reason it went outside of canvas

            OriginalScale = transform.localScale;
            ExpandedScale = GetComponentInParent<NotebookContainer>().Center.gameObject.transform.localScale;
        }

        public void Update()
        {
            if (transform.hasChanged && State == MoveState.Stand && transform.position != ExpandedPosition)
                OriginalPosition = transform.position;

            if (State == MoveState.Shrink)
                Move(OriginalPosition, OriginalScale);
            else if (State == MoveState.Expand)                
                Move(ExpandedPosition, ExpandedScale);
        }

        public void OnPointerClick(PointerEventData pointer) {
            if (transform.position == OriginalPosition && transform.localScale == OriginalScale)
                Expand();
        }

        private void Move(Vector3 MoveTo, Vector3 ScaleTo)
        {
            transform.position = Vector3.MoveTowards(transform.position, MoveTo, speed * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, ScaleTo, scaleSpeed * Time.deltaTime);

            if (transform.position == MoveTo && transform.localScale == ScaleTo)
            {
                if (MoveTo == ExpandedPosition && ScaleTo == ExpandedScale)
                {
                    GetComponentInParent<NotebookContainer>().ActivePage(int.Parse(this.name));
                    GetComponent<Animator>().SetTrigger(ActionName);
                    Highlighted = true;
                } else
                {
                    Highlighted = false;
                }

                State = MoveState.Stand;
            }
        }

        [Command]
        public void Expand()
        {
            State = MoveState.Expand;
        }

        [Command]
        public void Shrink()
        {
            State = MoveState.Shrink;
        }
    }
}
