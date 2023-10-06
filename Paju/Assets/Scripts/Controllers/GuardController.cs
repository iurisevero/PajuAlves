using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    public BoxCollider northSemaphoreCollider, southSemaphoreCollider;
    public BoxCollider westSemaphoreCollider, eastSemaphoreCollider;
    public MeshRenderer northSemaphoreRenderer, southSemaphoreRenderer;
    public MeshRenderer westSemaphoreRenderer, eastSemaphoreRenderer;
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

        northSemaphoreCollider.enabled = !true;
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

        eastSemaphoreCollider.enabled = !true;
        eastSemaphoreRenderer.material = openSemaphoreMaterial;
        guardPrefab.transform.rotation = Quaternion.Euler(0, MoveDirection.East.ToFloat(), 0);
    }

    public void SetSouthSemaphore() {
        Debug.Log("SetSouth");
        northSemaphoreCollider.enabled = true;
        eastSemaphoreCollider.enabled = true;
        westSemaphoreCollider.enabled = true;
        northSemaphoreRenderer.material = closeSemaphoreMaterial;
        eastSemaphoreRenderer.material = closeSemaphoreMaterial;
        westSemaphoreRenderer.material = closeSemaphoreMaterial;

        southSemaphoreCollider.enabled = !true;
        southSemaphoreRenderer.material = openSemaphoreMaterial;
        guardPrefab.transform.rotation = Quaternion.Euler(0, MoveDirection.South.ToFloat(), 0);
    }

    public void SetWestSemaphore() {
        Debug.Log("SetWest");
        northSemaphoreCollider.enabled = true;
        eastSemaphoreCollider.enabled = true;
        southSemaphoreCollider.enabled = true;
        northSemaphoreRenderer.material = closeSemaphoreMaterial;
        eastSemaphoreRenderer.material = closeSemaphoreMaterial;
        southSemaphoreRenderer.material = closeSemaphoreMaterial;

        westSemaphoreCollider.enabled = !true;
        westSemaphoreRenderer.material = openSemaphoreMaterial;
        guardPrefab.transform.rotation = Quaternion.Euler(0, MoveDirection.West.ToFloat(), 0);
    }
}
