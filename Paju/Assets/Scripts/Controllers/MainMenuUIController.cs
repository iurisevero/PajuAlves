using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < levelButtons.Length; ++i) {
            int levelIndex = GameController.Instance.levels[i].index;
            int levelWinPoints = GameController.Instance.levels[i].winPoints;
            levelButtons[i].onClick.AddListener(delegate {
                GameController.Instance.GoToLevel(
                    levelIndex, levelWinPoints
                ); 
            });
            levelButtons[i].interactable = !GameController.Instance.levels[i].completed;
        }
    }

    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
