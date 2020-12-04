using UnityEngine;
using UnityEngine.UI;

namespace Intro.ViewTriggers
{
    class ViewFour : MonoBehaviour
    {
        [SerializeField]
        GameObject MoveOn;
        [SerializeField]
        GameObject TextBox;
        [SerializeField]
        Vector2 NewPosition;

        private void onDisable()
        {
            MoveOn.SetActive(false);
        }

        private void OnEnable()
        {
            TextBox.transform.position = NewPosition;
            MoveOn.SetActive(true);
            TextBox.GetComponentInChildren<Button>().gameObject.SetActive(false);
        }
    }
}
