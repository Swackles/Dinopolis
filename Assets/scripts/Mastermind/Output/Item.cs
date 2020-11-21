using UnityEngine;

namespace Mastermind.Output
{
    public class Item : MonoBehaviour
    {
        public Main.Result Selected = 0;

        void Awake()
        {
            // Hides all emotions in the start of the round
            for (int i = 0; i <= 3; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Show result
        /// </summary>
        /// <param name="result">Result to show</param>
        public void Show(Main.Result result)
        {
            if (result != 0)
            {
                this.transform.GetChild((int)Selected).gameObject.SetActive(false); // Hides active element
                this.transform.GetChild((int)result).gameObject.SetActive(true); // Shows newly activated one
            }

            Selected = result;
        }
    }

}
