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
        Debug.Log($"LevelButtons Lenght: {levelButtons.Length}; Levels Lenght: {GameController.Instance.levels.Length}");
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
}
