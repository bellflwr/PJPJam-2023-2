using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject menu;
    
    public bool Paused = false;

    public void PauseGame() {
        menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Paused = true;
        Time.timeScale = 0;
        Debug.Log("Game has paused");
    }
    
    public void ResumeGame() {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Paused = false;
        Time.timeScale = 1;
        Debug.Log("Game has resumed");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !Paused) {
            PauseGame();
        }
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }


}
