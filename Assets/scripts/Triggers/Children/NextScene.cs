using UnityEngine;
using UnityEngine.SceneManagement;

namespace Triggers.Children
{
    class NextScene : MonoBehaviour, IChild
    {
        public void StartUp()
        {

        }

        public void Action()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void AfterAction()
        {

        }

        public bool Finished()
        {
            return false; //This child never finishes
        }
    }
}
