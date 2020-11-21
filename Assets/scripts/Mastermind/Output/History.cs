using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

namespace Mastermind.Output
{
    [CommandPrefix("mastermind.output.history.")]
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
                    ItemContainers[0].Show(result);
                }
                else
                {
                    ItemContainers[i].Show(ItemContainers[i - 1].Value());
                }
            }

        }
    }
}
