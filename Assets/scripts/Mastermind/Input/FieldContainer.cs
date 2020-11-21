using System.Linq;
using UnityEngine;
using QFSW.QC;

namespace Mastermind.Input
{
    [CommandPrefix("Mastermind.Input.")]
    public class FieldContainer : MonoBehaviour
    {
        /// <summary>
        /// Gets values of input fields
        /// </summary>
        /// <returns></returns>
        [Command]
        public int?[] Values()
        {
            Field[] Children = GetComponentsInChildren<Field>();

            return Children.Select(x => x.Value).ToArray();
        }

        /// <summary>
        /// Get values of input fields, null values are removed
        /// </summary>
        /// <returns></returns>
        public int[] SafeValues()
        {
            return Values().Where(x => x != null).Select(x => (int)x).ToArray();
        }

        /// <summary>
        /// Are all fields are filled
        /// </summary>
        /// <returns></returns>
        public bool ValuesFilled()
        {
            return Values().Length == SafeValues().Length;
        }

        /// <summary>
        /// Count how many InputSlots exist
        /// </summary>
        public int Count()
        {
           return GetComponentsInChildren<Field>().Length;
        }
    }
}
