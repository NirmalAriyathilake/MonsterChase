using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour {
    private string MAIN_MENU_SCENE = "MainMenu";

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HomeButton() {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}
