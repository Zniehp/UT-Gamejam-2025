using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneend : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ChangeSceneToMenu());
    }
    IEnumerator ChangeSceneToMenu()
    {
        yield return new WaitForSeconds(14);

        SceneManager.LoadScene("MainMenu");
    }

  
}
