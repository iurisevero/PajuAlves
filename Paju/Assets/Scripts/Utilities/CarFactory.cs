using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarFactory : MonoBehaviour
{
    private List<Poolable> instantiatedCars;
    public MoveDirection toMoveDirection;
    public ToSpawnCar[] toSpawnCars;
    public GameObject ambulanceAlertObj;

    void Start()
    {
        ambulanceAlertObj.SetActive(false);
        instantiatedCars = new List<Poolable>();
        StartCoroutine(SpawnCars());
    }

    void Update()
    {
        if(GameController.Instance.gameOver && instantiatedCars.Count > 0)
            EnqueueAll();
    }

    GameObject Dequeue(string key){
        Poolable poolObj = GameObjectPoolController.Dequeue(key);
        instantiatedCars.Add(poolObj);
        return poolObj.gameObject;
    }

    void EnqueueAll(){
        foreach(Poolable p in instantiatedCars) {
            if(p.gameObject.activeSelf)
                GameObjectPoolController.Enqueue(p);
        }
        instantiatedCars.Clear();
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
        for(int i=0; i < toSpawnCars.Length; ++i) {
            Debug.Log($"{this.gameObject} waiting {toSpawnCars[i].time} to spawn {toSpawnCars[i].key}");
            yield return new WaitForSeconds(toSpawnCars[i].time);
            GameObject car = Dequeue(Constants.GetCarPoolKey(toSpawnCars[i].key));
            if(toSpawnCars[i].key == CarPoolKey.Ambulance) {
                AudioManager.Instance.Play("Ambulance");
                StartCoroutine(AlertAmbulance());
                yield return new WaitForSeconds(1f);
            } else {
                ambulanceAlertObj.SetActive(false);
            }
            ConfigureCar(car);
        }
    }

    IEnumerator AlertAmbulance() {
        ambulanceAlertObj.SetActive(true);
        yield return new WaitForSeconds(2f);
        ambulanceAlertObj.SetActive(false);
    }
}
