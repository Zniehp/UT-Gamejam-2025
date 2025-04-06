using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public void GoToDeathScene()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
