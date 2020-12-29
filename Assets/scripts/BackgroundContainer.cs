using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class BackgroundContainer: MonoBehaviour
{
    Image[] Backgrounds;
    int Active = 0;

    private void Awake()
    {
        Backgrounds = GetComponentsInChildren<Image>();

        for (int i = 1; i < Backgrounds.Length; i++)
        {
            Backgrounds[i].color = new Color(1, 1, 1, 0);
        }
    }

    public void Next()
    {
        if (Backgrounds != null && Active < Backgrounds.Length)
        {
            Backgrounds[Active].color = new Color(1, 1, 1, 0);
            Active++;
            Backgrounds[Active].color = new Color(1, 1, 1, 1);
        }
        else if(Active == 3)
        {
            SceneManager.LoadScene(1);
        }
    }
}
