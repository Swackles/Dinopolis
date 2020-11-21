using UnityEngine;

namespace Mastermind.Inventory
{
    public class ItemContainer : MonoBehaviour
    {
        public int Count()
        {
            return GetComponentsInChildren<Item>().Length;
        }
    }
}
