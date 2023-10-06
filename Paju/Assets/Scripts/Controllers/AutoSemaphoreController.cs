using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSemaphoreController : MonoBehaviour
{
    public BoxCollider northSemaphoreCollider, southSemaphoreCollider;
    public BoxCollider westSemaphoreCollider, eastSemaphoreCollider;
    public MeshRenderer northSemaphoreRenderer, southSemaphoreRenderer;
    public MeshRenderer westSemaphoreRenderer, eastSemaphoreRenderer;
    public Material openSemaphoreMaterial, closeSemaphoreMaterial;
    public bool horizontalSemaphoreOn = true, horizontalCountDown = false, verticalCountDown = false;
    public float currentCountDownTime = Constants.maxCountDown;
    public float horizontalTime = 5.0f, verticalTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        SetHorizontalSemaphores();
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontalCountDown) {
            currentCountDownTime -= Time.deltaTime;
            Debug.Log($"Horizontal Counting down");
        }

        if(verticalCountDown) {
            currentCountDownTime -= Time.deltaTime;
            Debug.Log($"Vertical Counting down");
        }

        if(horizontalSemaphoreOn && !horizontalCountDown) {
            horizontalCountDown = true;
            currentCountDownTime = horizontalTime;
        }

        if(!horizontalSemaphoreOn && !verticalCountDown) {
            verticalCountDown = true;
            currentCountDownTime = verticalTime;
        }

        if(horizontalSemaphoreOn && horizontalCountDown && (int) currentCountDownTime == 0) {
            SetVerticalSemaphores();
        }

        if(!horizontalSemaphoreOn && verticalCountDown && (int) currentCountDownTime == 0) {
            SetHorizontalSemaphores();
        }
    }

    public void SwitchSemaphore() {
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
        verticalCountDown = false;
        horizontalCountDown = false;
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
        verticalCountDown = false;
        horizontalCountDown = false;
    }

    public void UpdateVerticalTime(string value) {
        verticalTime = int.Parse(value);
    }

    public void UpdateHorizontalTime(string value) {
        horizontalTime = int.Parse(value);
    }
}
