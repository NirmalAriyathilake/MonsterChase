using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private string GAME_PLAY_SCENE = "GamePlay";

    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex {
        get { return _charIndex; }
        set { _charIndex = value; }
    }


    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        if(scene.name == GAME_PLAY_SCENE) {
            Instantiate(characters[CharIndex]);
        }
    }
}
