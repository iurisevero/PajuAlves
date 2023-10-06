using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour
{
    public GameObject carPrefab;
    public MoveDirection toMoveDirection;
    public CarPoolKey[] toSpawnCarsKey;
    public float[] toSpawnCarsTime;

    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    GameObject Dequeue(string key){
        Poolable poolObj = GameObjectPoolController.Dequeue(key);
        return poolObj.gameObject;
    }

    void ConfigureCar(GameObject carObj) {
        CarController carController = carObj.GetComponent<CarController>();
        carController.moveDirection = toMoveDirection;
        carController.move = true;
        carObj.transform.localScale = Vector3.one;
        carObj.transform.position = transform.position;
        carObj.gameObject.SetActive(true);
    }

    IEnumerator SpawnCars() {
        for(int i=0; i < toSpawnCarsKey.Length; ++i) {
            yield return new WaitForSeconds(toSpawnCarsTime[i]);
            GameObject car = Dequeue(Constants.GetCarPoolKey(toSpawnCarsKey[i]));
            ConfigureCar(car);
        }
    }
}
