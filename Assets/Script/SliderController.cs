using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    bool ispaused = false;
    public GameObject EndScene;
    static public float duration = 15.0f;
    public Slider slider;
    float elapsedTime = 0f;
    float startValue = 1f;
    float endValue = 0f;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        EndScene.SetActive(false);
        duration = 15.0f;
        elapsedTime = 0f;
        startValue = 1f;
        endValue = 0f;
    }
    private void Update()
    {
        if (slider.value == 0f)
        {
            EndScene.SetActive(true);
            Time.timeScale = 0f;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        if (!ispaused)
        {
            EndScene.SetActive(true);
            Time.timeScale = 0f;
            ispaused = true;
            return;
        }
        if (ispaused)
        {
            EndScene.SetActive(false);
            Time.timeScale = 1f;
            ispaused = false;
            return;
        }
    }

    public void TimeStart()
    {
        print("Coroutine Stop");
        StopAllCoroutines();
        slider.value = 1f;
        elapsedTime = 0f;
        StartCoroutine(StartAfterDelay());
    }

    private IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(DecreaseSliderValue());
    }

    private IEnumerator DecreaseSliderValue()
    {
        print("In the couritine"); 
        startValue = 1f;

        while (elapsedTime < duration)
        {
            // Interpolate between start and end values over time
            slider.value = Mathf.Lerp(startValue, endValue, elapsedTime / duration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the slider value reaches the end value exactly
        slider.value = endValue;
    }
}
