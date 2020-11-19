using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using QFSW.QC;

namespace Mastermind
{
    [CommandPrefix("Mastermind.")]
    public class Main : MonoBehaviour
    {
        [SerializeField]
        private OutputContainer Output; // Output to show to the player
        [SerializeField]
        private InputFieldContainer Input; // The player input
        [SerializeField]
        private Inventory Inventory;
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
            // There must be equal amounts of inputs and outputs
            if (Output.Count() != Input.Count()) { throw new Exception("IO Count error"); }
            // If there are more IOs then InventoryItems
            if (Output.Count() > Inventory.Count()) { throw new Exception("Too many IOs"); }

            List<int> TempSolutions = new List<int>();
            // Generate the solution with length equal to user input lenght
            for (int i = 0; i < Output.Count(); i++)
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

        [Command]
        public static void Submit()
        {
            Main mastermind = FindObjectOfType<Main>();

            InputFieldContainer Input = mastermind.Input;

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
            mastermind.Output.Show(TempOutput.OrderBy(x => x).ToArray());
        }
    }
}
