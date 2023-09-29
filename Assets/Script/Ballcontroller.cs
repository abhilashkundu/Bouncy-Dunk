using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour
{
    private Rigidbody2D ballRigidbody2D;

    public float clampX = 7f;

    [SerializeField] private GameObject[] Scene;
    public SliderController sliderController;
    public int currentScene;

    public void ResetSlider()
    {
        clampX = 7f;
    }
    private void Awake()
    {
        for (int i = 0; i < Scene.Length; i++) { Scene[i].SetActive(false); }

        ballRigidbody2D = GetComponent<Rigidbody2D>();
        currentScene = Random.Range(0, 2);
        Scene[currentScene].SetActive(true);
        Scene[currentScene].GetComponent<Animator>().SetTrigger("Enter");
        GameObject.FindGameObjectWithTag("slider").GetComponent<SliderController>().TimeStart();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Scene[0].activeInHierarchy)
        {
            print("Click");
            ballRigidbody2D.AddForce(Vector2.up * 1200);
            ballRigidbody2D.AddForce(Vector2.right * 300, ForceMode2D.Force);
        }
        if (Input.GetMouseButtonDown(0) && Scene[1].activeInHierarchy)
        {
            print("Click");
            ballRigidbody2D.AddForce(Vector2.up * 1200);
            ballRigidbody2D.AddForce(Vector2.left * 300, ForceMode2D.Force);
        }

        if (transform.position.x > clampX)
        {
            transform.position = new Vector3(-clampX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -clampX)
        {
            transform.position = new Vector3(clampX, transform.position.y, transform.position.z);
        }
    }

    public void SceneChanger()
    {
        sliderController.TimeStart();
        if (currentScene == 0)
        {
            Scene[0].SetActive(false);
            //float count = Random.Range(0.86f, 2.88f);
            //print(count);
            //Scene[1].transform.position = new Vector3(Scene[1].transform.position.x, count, Scene[1].transform.position.z);
            Scene[1].SetActive(true);
            Scene[1].GetComponent<Animator>().SetTrigger("Enter");
            currentScene = 1;
            return;
        }
        if(currentScene == 1)
        {
            Scene[1].SetActive(false);
            //float count = Random.Range(0.86f, 2.88f);
            //print(count);
            //Scene[1].transform.position = new Vector3(Scene[1].transform.position.x, count, Scene[1].transform.position.z);
            Scene[0].SetActive(true);
            Scene[0].GetComponent<Animator>().SetTrigger("Enter");
            currentScene = 0;
            return;
        }
    }
}
