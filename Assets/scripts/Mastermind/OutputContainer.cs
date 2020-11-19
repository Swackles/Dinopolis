using System.Linq;
using UnityEngine;
using QFSW.QC;

namespace Mastermind
{
    [CommandPrefix("Mastermind.Output")]
    public class OutputContainer : MonoBehaviour
    {
        /// <summary>
        /// Show surtain outputs
        /// </summary>
        /// <param name="result">Array of results to show</param>
        [Command]
        public void Show(Main.Result[] result)
        {
            foreach (var Item in GetComponentsInChildren<Output>().Select((Value, Index) => new { Index, Value }))
            {

                Item.Value.Show(result[Item.Index]);
            }
            
        }

        /// <summary>
        /// Show output at specific index
        /// </summary>
        /// <param name="Result">Result to show</param>
        /// <param name="Index">Output index position</param>
        [Command]
        public void Show(Main.Result Result, int Index)
        {
            GetComponentsInChildren<Output>()[Index].Show(Result);
        }

        /// <summary>
        /// Count how many Outputs exist
        /// </summary>
        [Command]
        public int Count()
        {
            return GetComponentsInChildren<Output>().Length;
        }
    }
}
