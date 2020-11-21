using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

namespace Mastermind.Output
{
    [CommandPrefix("Mastermind.Output.")]
    public class ItemContainer : MonoBehaviour
    {
        private Item[] Items;

        /// <summary>
        /// Value of output
        /// </summary>
        [Command("Value", MonoTargetType.All)]
        public Main.Result[] Value
        {
            get
            {
                List<Main.Result> result = new List<Main.Result>();

                for (int i = 0; i < Items.Length; i++)
                {
                    result.Add(Items[i].Selected);
                }

                return result.ToArray();

            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    Items[i].Show(value[i]);
                }
            }
        }

        private void Awake()
        {
            Items = GetComponentsInChildren<Item>();
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
