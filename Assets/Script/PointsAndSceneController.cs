using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsAndSceneController : MonoBehaviour
{
    private static int totalPoints = 0;
    public GameObject bottomCollider;

    public TextMeshProUGUI score;
    public TextMeshProUGUI EndGamescore;
    Ballcontroller ballController;

    private void Awake()
    {
        ballController = FindAnyObjectByType<Ballcontroller>();
    }
    public void Reset()
    {
        totalPoints = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Ball"))
        {
                bottomCollider.SetActive(false);
                totalPoints += 10;
                score.text = ("SCORE : " + totalPoints);
                EndGamescore.text = ("SCORE : " + totalPoints);
                print(totalPoints);
                ballController.SceneChanger();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            bottomCollider.SetActive(true);
        }
    }
}
