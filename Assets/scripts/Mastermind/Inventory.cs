using UnityEngine;
using QFSW.QC;

namespace Mastermind
{
    [CommandPrefix("Mastermind.Inventory.")]
    public class Inventory : MonoBehaviour
    {
        [Command]
        public int Count()
        {
            return GetComponentsInChildren<InventoryItem>().Length;
        }
    }
}
