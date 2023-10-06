using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    private int winPoints;
    public Level[] levels;
    public GameObject blueCarPrefab;
    public GameObject orangeCarPrefab;
    public GameObject redCarPrefab;
    public UIController uiController;
    public bool gameOver { private set; get; }
    public int totalPoints {private set; get; }

    void Start()
    {
        gameOver = false;
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.BlueCar), blueCarPrefab, 5, 10);
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.OrangeCar), orangeCarPrefab, 5, 10);
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.RedCar), redCarPrefab, 5, 10);
        totalPoints = 0;
    }

    public void GameOver() {
        Debug.Log("GameController GameOver");
        gameOver = true;
        uiController.ShowLose();
    }

    public void AddPoints(int pointsToAdd) {
        totalPoints += pointsToAdd;
        uiController.UpdatePoints(totalPoints.ToString());

        if(totalPoints == winPoints) {
            uiController.ShowWin();
        }
    }

    public void GoToLevel(int index, int toWinPoints) {
        winPoints = toWinPoints;
        SceneManager.LoadScene(index);
    }
}
