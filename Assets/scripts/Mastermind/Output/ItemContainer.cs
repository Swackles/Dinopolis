using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

namespace Mastermind.Output
{
    [CommandPrefix("Mastermind.Output.")]
    public class ItemContainer : MonoBehaviour
    {
        private Item[] Items;

        private void Awake()
        {
            Items = GetComponentsInChildren<Item>();
        }

        /// <summary>
        /// Set the current value of outputs
        /// </summary>
        /// <param name="result">Array of results to show</param>
        public void Show(Main.Result[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                Items[i].Show(result[i]);
            }
        }

        /// <summary>
        /// Get the current value of outputs
        /// </summary>
        /// <returns></returns>
        [Command]
        public Main.Result[] Value()
        {
            List<Main.Result> result = new List<Main.Result>();

            for (int i = 0; i < Items.Length; i++)
            {
                result.Add(Items[i].Selected);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Count how many Outputs exist
        /// </summary>
        public int Count()
        {
            return GetComponentsInChildren<Item>().Length;
        }
    }
}
