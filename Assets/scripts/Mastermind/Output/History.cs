using System;
using UnityEngine;
using QFSW.QC;

namespace Mastermind.Output
{
    [CommandPrefix("Mastermind.Output.")]
    public class History : MonoBehaviour
    {
        private ItemContainer[] ItemContainers;
        private void Awake()
        {
            ItemContainers = GetComponentsInChildren<ItemContainer>();
            Array.Reverse(ItemContainers);
        }

        /// <summary>
        /// Push new value to the history
        /// </summary>
        /// <param name="result"></param>
        [Command]
        public void Push(Main.Result[] result)
        {

            for(int i = ItemContainers.Length - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    ItemContainers[0].Value = result;
                }
                else
                {
                    ItemContainers[i].Value = ItemContainers[i - 1].Value;
                }
            }

        }
    }
}
