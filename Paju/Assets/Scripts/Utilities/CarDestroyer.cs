using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CarDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit) {
        if(hit.gameObject.tag == Constants.carTag) {
            GameController.Instance.AddPoints(hit.gameObject.GetComponent<CarController>().pointsToAdd);
            Enqueue(hit.gameObject);
        }
    } 

    void Enqueue(GameObject portraitObject){
        Poolable p = portraitObject.GetComponent<Poolable>();
        GameObjectPoolController.Enqueue(p);
    }
}
