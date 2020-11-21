using UnityEngine;

namespace Mastermind
{
    public class Submit : MonoBehaviour
    {
        public void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Main.Submit();
            }
        }
    }
}