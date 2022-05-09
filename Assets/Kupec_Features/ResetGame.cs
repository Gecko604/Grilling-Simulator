using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(resetGame());
    }

    public void StartGameReset()
    {
        StartCoroutine(resetGame());
    }

    public void ExitGame()
    {
        StartCoroutine(exitGame());
    }

    IEnumerator resetGame()
    {
        Debug.Log("Restarting in 3 seconds..");
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator exitGame()
    {
        Debug.Log("Exiting in 3 seconds..");
        yield return new WaitForSeconds(3);

        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
