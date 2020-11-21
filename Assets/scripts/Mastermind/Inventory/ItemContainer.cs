using UnityEngine;
using QFSW.QC;

namespace Mastermind.Inventory
{
    [CommandPrefix("Mastermind.Inventory.")]
    public class ItemContainer : MonoBehaviour
    {
        [Command]
        public int Count()
        {
            return GetComponentsInChildren<Item>().Length;
        }
    }
}
