using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using QFSW.QC;
using Mastermind.Input;
using Mastermind.Output;

namespace Mastermind
{
    [CommandPrefix("Mastermind.")]
    public class Main : MonoBehaviour
    {
        [SerializeField]
        private History Output; // Output to show to the player
        [SerializeField]
        private FieldContainer Input; // The player input
        [SerializeField]
        private Inventory.ItemContainer Inventory;
        [Command]
        private int[] Solution; // Solutions
        public enum Result
        {
            Neutral = 0,
            Correct = 1,
            FalsePos = 2,
            False = 3
        }

        private void Awake()
        {

            List<int> TempSolutions = new List<int>();
            // Generate the solution with length equal to user input lenght
            for (int i = 0; i < Input.Count(); i++)
            {
                int Number = -1;
                // Generate one number of solution untill solution already dosen't contain it
                while (Number == -1 || TempSolutions.Contains(Number))
                {
                    Number = UnityEngine.Random.Range(0, Inventory.Count() - 1);
                }
                TempSolutions.Add(Number);
            }

            Solution = TempSolutions.ToArray();
        }

        /// <summary>
        /// Submits the input
        /// </summary>
        [Command]
        [CommandDescription("Submits the input")]
        public static void Submit()
        {
            Main mastermind = FindObjectOfType<Main>();

            FieldContainer Input = mastermind.Input;

            if (!Input.ValuesFilled()) { return; }

            int[] Solution = mastermind.Solution;
            int[] Inputs = Input.SafeValues();
            List<Result> TempOutput = new List<Result>();

            for (int i = 0; i < Solution.Length; i++)
            {
                if (Inputs[i] == Solution[i])
                {
                    TempOutput.Add(Result.Correct);
                }
                else if (Solution.Contains(Inputs[i]))
                {
                    TempOutput.Add(Result.FalsePos);
                }
                else
                {
                    TempOutput.Add(Result.False);
                }
            }

            // Send output to Output container
            mastermind.Output.Push(TempOutput.OrderBy(x => x).ToArray());
        }
    }
}
