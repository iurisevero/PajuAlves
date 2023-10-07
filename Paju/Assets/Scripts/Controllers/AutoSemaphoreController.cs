using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject northCountDownObj, westCountDownObj;
    public Image northCountDownImage, westCountDownImage, currentCountDownImage;
    public TextMeshProUGUI northCountText, westCountText, currentCountText;

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
            currentCountText.text = Mathf.CeilToInt(currentCountDownTime).ToString();
            currentCountDownImage.fillAmount = (
                100.0f - (currentCountDownTime * 100.0f / horizontalTime)
            )/100.0f;
            Debug.Log($"Horizontal Counting down");
        }

        if(verticalCountDown) {
            currentCountDownTime -= Time.deltaTime;
            currentCountText.text = Mathf.CeilToInt(currentCountDownTime).ToString();
            currentCountDownImage.fillAmount = (
                100.0f - (currentCountDownTime * 100.0f / verticalTime)
            )/100.0f;
            Debug.Log($"Vertical Counting down");
        }

        if(horizontalSemaphoreOn && !horizontalCountDown) {
            horizontalCountDown = true;
            currentCountDownTime = horizontalTime;
            currentCountDownImage = westCountDownImage;
            currentCountText = westCountText;
            currentCountDownImage.fillAmount = 0;
            westCountDownObj.SetActive(true);
        }

        if(!horizontalSemaphoreOn && !verticalCountDown) {
            verticalCountDown = true;
            currentCountDownTime = verticalTime;
            currentCountDownImage = northCountDownImage;
            currentCountText = northCountText;
            currentCountDownImage.fillAmount = 0;
            northCountDownObj.SetActive(true);
        }

        if(horizontalSemaphoreOn && horizontalCountDown && currentCountDownTime <= 0) {
            SetVerticalSemaphores();
        }

        if(!horizontalSemaphoreOn && verticalCountDown && currentCountDownTime <= 0) {
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
        northCountDownObj.SetActive(false);
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
        westCountDownObj.SetActive(false);
    }
}
