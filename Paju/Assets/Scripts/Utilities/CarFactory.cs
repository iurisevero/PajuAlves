using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour
{
    private const string CarObjectPoolKey = "Car";
    public GameObject carPrefab;
    public MoveDirection toMoveDirection;

    void Start()
    {
        GameObjectPoolController.AddEntry(CarObjectPoolKey, carPrefab, 5, 10);
    }

    GameObject Dequeue(){
        Poolable poolObj = GameObjectPoolController.Dequeue(CarObjectPoolKey);
        return poolObj.gameObject;
    }

    void Enqueue(GameObject portraitObject){
        Poolable p = portraitObject.GetComponent<Poolable>();
        GameObjectPoolController.Enqueue(p);
    }

    void ConfigureCar(GameObject carObj) {
        CarController carController = carObj.GetComponent<CarController>();
        carController.moveDirection = toMoveDirection;
        carController.move = true;
        carObj.transform.localScale = Vector3.one;
        carObj.transform.position = transform.position;
        carObj.gameObject.SetActive(true);
    }

    public void CreateCar() {
        GameObject car = Dequeue();
        ConfigureCar(car);
    }
}
