using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void GoToScene(int scene) {
        SceneManager.LoadScene(scene);
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}