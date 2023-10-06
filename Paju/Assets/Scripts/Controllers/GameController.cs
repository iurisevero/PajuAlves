using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public GameObject blueCarPrefab;
    public GameObject orangeCarPrefab;
    public GameObject redCarPrefab;

    void Start()
    {
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.BlueCar), blueCarPrefab, 5, 10);
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.OrangeCar), orangeCarPrefab, 5, 10);
        GameObjectPoolController.AddEntry(Constants.GetCarPoolKey(CarPoolKey.RedCar), redCarPrefab, 5, 10);
    }
}
