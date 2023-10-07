using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    private int winPoints;
    public Level[] levels;
    public GameObject yellowCarPrefab;
    public GameObject orangeCarPrefab;
    public GameObject blueTruckPrefab;
    public GameObject pinkTruckPrefab;
    public GameObject ambulancePrefab;
    public UIController uiController;
    public bool gameOver { private set; get; }
    public bool win { private set; get; }
    public int totalPoints;
    public int acumulatedPoints;

    void Start()
    {
        winPoints = 5000;
        gameOver = false;
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.YellowCar), yellowCarPrefab, 5, 10);
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.OrangeCar), orangeCarPrefab, 5, 10);
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.BlueTruck), blueTruckPrefab, 5, 10);
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.PinkTruck), pinkTruckPrefab, 5, 10);
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.Ambulance), ambulancePrefab, 5, 10);
        totalPoints = 0;
        acumulatedPoints = 0;
        AudioManager.Instance.Play("Menu");
        AudioManager.Instance.Stop("InGame1");
        AudioManager.Instance.Stop("InGame2");
    }

    public void GameOver() {
        Debug.Log("GameController GameOver");
        gameOver = true;
        uiController.ShowLose();
        AudioManager.Instance.Play("Lose");
        Invoke("ReturnToMenu", 5f);
    }

    public void Win() {
        Debug.Log("GameController Win");
        win = true;
        uiController.ShowWin();
        // levels[SceneManager.GetActiveScene().buildIndex - 1].completed = true;
        AudioManager.Instance.Play("Win");
        Invoke("ReturnToMenu", 5f);
    }

    public void AddPoints(int pointsToAdd) {
        totalPoints += pointsToAdd;
        acumulatedPoints += pointsToAdd;
        uiController.UpdatePoints(totalPoints.ToString());

        if(acumulatedPoints >= winPoints) {
            Win();
        }
    }

    public void GoToLevel(int index, int toWinPoints) {
        winPoints = toWinPoints;
        totalPoints = 0;
        acumulatedPoints = 0;
        SceneManager.LoadScene(index);
        AudioManager.Instance.Stop("Menu");
        AudioManager.Instance.Play("InGame" + UnityEngine.Random.Range(1, 3).ToString());
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
        gameOver = false;
        win = false;
        AudioManager.Instance.Play("Menu");
        AudioManager.Instance.Stop("InGame1");
        AudioManager.Instance.Stop("InGame2");
        AudioManager.Instance.Stop("Ambulance");
    }
}
