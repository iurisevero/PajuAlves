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

    // Start is called before the first frame update
    void Start()
    {
        SetHorizontalSemaphores();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchSemaphore() {
        AudioManager.Instance.Play("Click");
        if(horizontalSemaphoreOn) {
            SetVerticalSemaphores();
        } else {
            SetHorizontalSemaphores();
        }
    }

    public void SetHorizontalSemaphores() {
        Debug.Log("SetHorizontal");
        westSemaphoreCollider.enabled = true;
        eastSemaphoreCollider.enabled = true;
        westSemaphoreRenderer.material = closeSemaphoreMaterial;
        eastSemaphoreRenderer.material = closeSemaphoreMaterial;

        northSemaphoreCollider.enabled = !true;
        southSemaphoreCollider.enabled = !true;
        northSemaphoreRenderer.material = openSemaphoreMaterial;
        southSemaphoreRenderer.material = openSemaphoreMaterial;

        horizontalSemaphoreOn = true;
    }

    public void SetVerticalSemaphores() {
        Debug.Log("SetVertical");
        northSemaphoreCollider.enabled = true;
        southSemaphoreCollider.enabled = true;
        northSemaphoreRenderer.material = closeSemaphoreMaterial;
        southSemaphoreRenderer.material = closeSemaphoreMaterial;

        westSemaphoreCollider.enabled = !true;
        eastSemaphoreCollider.enabled = !true;
        westSemaphoreRenderer.material = openSemaphoreMaterial;
        eastSemaphoreRenderer.material = openSemaphoreMaterial;

        horizontalSemaphoreOn = false;
    }
}
