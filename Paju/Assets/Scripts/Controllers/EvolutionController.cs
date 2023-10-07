using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionController : MonoBehaviour
{
    public int currentEvolution = 0;
    public int[] nextEvolutionPrice = {20, 90};
    public GameObject[] semaphores;
    public Sprite[] evolutionSprite;
    public GameObject evolveButtonObj;

    // Start is called before the first frame update
    void Start()
    {
        ActivateEvolution(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(
            currentEvolution < nextEvolutionPrice.Length && 
            GameController.Instance.totalPoints >= nextEvolutionPrice[currentEvolution]
        ) {
            evolveButtonObj.SetActive(true);
            evolveButtonObj.GetComponent<Image>().sprite = evolutionSprite[currentEvolution];
        } else {
            evolveButtonObj.SetActive(false);
        }
    }

    void ActivateEvolution(int evolution) {
        foreach(GameObject semaphore in semaphores) {
            semaphore.SetActive(false);
        }
        semaphores[evolution].SetActive(true);
        currentEvolution = evolution;
    }

    public void Evolve() {
        GameController.Instance.totalPoints -= nextEvolutionPrice[currentEvolution];
        ActivateEvolution(currentEvolution + 1);
    }
}
