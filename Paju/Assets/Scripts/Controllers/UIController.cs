using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIController : MonoBehaviour
{
    public Panel winPanel;
    public Panel losePanel;
    public TextMeshProUGUI totalPointsText;
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.uiController = this;
        totalPointsText.text = "0";
    }

    public void UpdatePoints(string pointsText) {
        totalPointsText.text = pointsText;
    }

    void TogglePos(string pos, Panel panel){
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 1f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    public void ShowWin(){
        TogglePos(Constants.showKey, winPanel);
    }

    public void HideWin(){
        TogglePos(Constants.hideKey, winPanel);
    }

    public void ShowLose(){
        TogglePos(Constants.showKey, losePanel);
    }

    public void HideLose(){
        TogglePos(Constants.hideKey, losePanel);
    }
}
