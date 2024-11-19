using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
