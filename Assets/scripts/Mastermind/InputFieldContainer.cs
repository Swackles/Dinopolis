﻿using System.Linq;
using UnityEngine;
using QFSW.QC;

namespace Mastermind
{
    [CommandPrefix("Mastermind.Input.")]
    public class InputFieldContainer : MonoBehaviour
    {
        /// <summary>
        /// Gets values of input fields also includes null values
        /// </summary>
        /// <returns></returns>
        [Command]
        public int?[] Values()
        {
            InputField[] Children = GetComponentsInChildren<InputField>();

            return Children.Select(x => x.Value).ToArray();
        }

        /// <summary>
        /// Get values of input fields, null values are removed
        /// </summary>
        /// <returns></returns>
        [Command]
        public int[] SafeValues()
        {
            return Values().Where(x => x != null).Select(x => (int)x).ToArray();
        }

        /// <summary>
        /// Get if all fields are filled
        /// </summary>
        /// <returns></returns>
        [Command("ValuesFilled", MonoTargetType.All)]
        public bool ValuesFilled()
        {
            return Values().Length == SafeValues().Length;
        }

        /// <summary>
        /// Count how many InputSlots exist
        /// </summary>
        [Command]
        public int Count()
        {
           return GetComponentsInChildren<InputField>().Length;
        }
    }
}
