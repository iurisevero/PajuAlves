using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardController : MonoBehaviour
{
    public BoxCollider northSemaphoreCollider, southSemaphoreCollider;
    public BoxCollider westSemaphoreCollider, eastSemaphoreCollider;
    public MeshRenderer northSemaphoreRenderer, southSemaphoreRenderer;
    public MeshRenderer westSemaphoreRenderer, eastSemaphoreRenderer;
    public Button northSemaphoreButton, southSemaphoreButton;
    public Button westSemaphoreButton, eastSemaphoreButton;
    public Material openSemaphoreMaterial, closeSemaphoreMaterial;
    public GameObject guardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetWestSemaphore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNorthSemaphore() {
        Debug.Log("SetNorth");
        westSemaphoreCollider.enabled = true;
        eastSemaphoreCollider.enabled = true;
        southSemaphoreCollider.enabled = true;
        westSemaphoreRenderer.material = closeSemaphoreMaterial;
        eastSemaphoreRenderer.material = closeSemaphoreMaterial;
        southSemaphoreRenderer.material = closeSemaphoreMaterial;
        westSemaphoreButton.interactable = true;
        eastSemaphoreButton.interactable = true;
        southSemaphoreButton.interactable = true;

        northSemaphoreCollider.enabled = false;
        northSemaphoreButton.interactable = false;
        northSemaphoreRenderer.material = openSemaphoreMaterial;
        guardPrefab.transform.rotation = Quaternion.Euler(0, MoveDirection.North.ToFloat(), 0);
    }

    public void SetEastSemaphore() {
        Debug.Log("SetEast");
        westSemaphoreCollider.enabled = true;
        northSemaphoreCollider.enabled = true;
        southSemaphoreCollider.enabled = true;
        westSemaphoreRenderer.material = closeSemaphoreMaterial;
        northSemaphoreRenderer.material = closeSemaphoreMaterial;
        southSemaphoreRenderer.material = closeSemaphoreMaterial;
        westSemaphoreButton.interactable = true;
        northSemaphoreButton.interactable = true;
        southSemaphoreButton.interactable = true;

        eastSemaphoreCollider.enabled = false;
        eastSemaphoreButton.interactable = false;
        eastSemaphoreRenderer.material = openSemaphoreMaterial;
        guardPrefab.transform.rotation = Quaternion.Euler(0, MoveDirection.East.ToFloat(), 0);
    }

    public void SetSouthSemaphore() {
        Debug.Log("SetSouth");
        westSemaphoreCollider.enabled = true;
        northSemaphoreCollider.enabled = true;
        eastSemaphoreCollider.enabled = true;
        westSemaphoreRenderer.material = closeSemaphoreMaterial;
        northSemaphoreRenderer.material = closeSemaphoreMaterial;
        eastSemaphoreRenderer.material = closeSemaphoreMaterial;
        westSemaphoreButton.interactable = true;
        northSemaphoreButton.interactable = true;
        eastSemaphoreButton.interactable = true;

        southSemaphoreCollider.enabled = false;
        southSemaphoreButton.interactable = false;
        southSemaphoreRenderer.material = openSemaphoreMaterial;
        guardPrefab.transform.rotation = Quaternion.Euler(0, MoveDirection.South.ToFloat(), 0);
    }

    public void SetWestSemaphore() {
        Debug.Log("SetWest");
        eastSemaphoreCollider.enabled = true;
        northSemaphoreCollider.enabled = true;
        southSemaphoreCollider.enabled = true;
        eastSemaphoreRenderer.material = closeSemaphoreMaterial;
        northSemaphoreRenderer.material = closeSemaphoreMaterial;
        southSemaphoreRenderer.material = closeSemaphoreMaterial;
        eastSemaphoreButton.interactable = true;
        northSemaphoreButton.interactable = true;
        southSemaphoreButton.interactable = true;

        westSemaphoreCollider.enabled = false;
        westSemaphoreButton.interactable = false;
        westSemaphoreRenderer.material = openSemaphoreMaterial;
        guardPrefab.transform.rotation = Quaternion.Euler(0, MoveDirection.West.ToFloat(), 0);
    }
}
