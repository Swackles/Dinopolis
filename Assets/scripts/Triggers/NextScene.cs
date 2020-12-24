using UnityEngine;
using UnityEngine.SceneManagement;

namespace Triggers
{
    class NextScene : Generic
    {
        public void Run()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
