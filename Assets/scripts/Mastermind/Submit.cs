using UnityEngine;

namespace Mastermind
{
    public class Submit : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Main.Submit();
            }
        }
    }
}