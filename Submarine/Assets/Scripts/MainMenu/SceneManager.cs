using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerer : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
