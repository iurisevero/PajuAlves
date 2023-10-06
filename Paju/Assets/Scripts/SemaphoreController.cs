using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaphoreController : MonoBehaviour
{
    public BoxCollider northSemaphoreCollider, southSemaphoreCollider;
    public BoxCollider westSemaphoreCollider, eastSemaphoreCollider;
    public MeshRenderer northSemaphoreRenderer, southSemaphoreRenderer;
    public MeshRenderer westSemaphoreRenderer, eastSemaphoreRenderer;
    public Material openSemaphoreMaterial, closeSemaphoreMaterial;
    public bool horizontalSemaphoreOn = true;
    public bool testBoolean = true;

    // Start is called before the first frame update
    void Start()
    {
        SetHorizontalSemaphores(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchSemaphore() {
        if(horizontalSemaphoreOn) {
            SetVerticalSemaphores(true);
        } else {
            SetHorizontalSemaphores(true);
        }
    }

    public void SetHorizontalSemaphores(bool isEnable) {
        Debug.Log($"SetHorizontal: {isEnable}");
        westSemaphoreCollider.enabled = isEnable;
        eastSemaphoreCollider.enabled = isEnable;
        westSemaphoreRenderer.material = closeSemaphoreMaterial;
        eastSemaphoreRenderer.material = closeSemaphoreMaterial;

        northSemaphoreCollider.enabled = !isEnable;
        southSemaphoreCollider.enabled = !isEnable;
        northSemaphoreRenderer.material = openSemaphoreMaterial;
        southSemaphoreRenderer.material = openSemaphoreMaterial;

        horizontalSemaphoreOn = true;
    }

    public void SetVerticalSemaphores(bool isEnable) {
        Debug.Log($"SetVertical: {isEnable}");
        northSemaphoreCollider.enabled = isEnable;
        southSemaphoreCollider.enabled = isEnable;
        northSemaphoreRenderer.material = closeSemaphoreMaterial;
        southSemaphoreRenderer.material = closeSemaphoreMaterial;

        westSemaphoreCollider.enabled = !isEnable;
        eastSemaphoreCollider.enabled = !isEnable;
        westSemaphoreRenderer.material = openSemaphoreMaterial;
        eastSemaphoreRenderer.material = openSemaphoreMaterial;

        horizontalSemaphoreOn = false;
    }
}
