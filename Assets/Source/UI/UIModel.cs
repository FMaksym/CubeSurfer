using UnityEngine;
using UnityEngine.SceneManagement;

public class UIModel : MonoBehaviour
{
    public void ActivateDeactivateCanvas(GameObject canvas, bool value)
    {
        canvas.SetActive(value);

        foreach (Transform child in canvas.transform)
        {
            child.gameObject.SetActive(value);
        }
    }


    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }
}
