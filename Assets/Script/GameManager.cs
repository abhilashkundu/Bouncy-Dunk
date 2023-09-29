using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Subscribe to the sceneLoaded event to reset the game on scene change
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ResetGame()
    {
        // Reset game-related elements and variables here

        // Reset points and scene controller (if you have one)
        PointsAndSceneController pointsAndSceneController = FindObjectOfType<PointsAndSceneController>();
        if (pointsAndSceneController != null)
        {
            //pointsAndSceneController.ResetPoints();
        }

        // Reset slider controller (if you have one)
        SliderController sliderController = FindObjectOfType<SliderController>();
        if (sliderController != null)
        {
            //sliderController.ResetSlider();
        }

        Ballcontroller ballcontroller = FindObjectOfType<Ballcontroller>();
        if (ballcontroller != null)
        {
            //ballcontroller.ResetSlider();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is the gameplay scene and reset the game
        if (scene.name == "GamePlay")
        {
            ResetGame();
        }
    }
}
