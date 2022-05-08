using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreGrade;

    //[Header("Level Information")]
    //public float maxLevelScore = 0;
    //public int numOrders = 0;

    //[Header("Customer Stats")]
    //public int happyCustomers = 0;
    //public int satisfiedCustomers = 0;
    //public int annoyedCustomers = 0;
   // public int angryCustomers = 0;

    [Header("Player Information")]
    public float playerScore = 0.0f;
    //public float customerRating = 0.0f;

    [Header("Payment Information")]
    public GameObject textPrefab = null;
    public Color refundRed = Color.red;
    public Color valueMealGreen = Color.green;


    [Header("Safety Information")]
    public int penalty = -5;

    [Header("Game Difficulty")]
    public int difficulty = 2;

    [SerializeField] private Restaurant_Manager director = null;
    public void Start()
    {
        director = GameObject.Find("Resturant_Position_Manager").GetComponent<Restaurant_Manager>();

        UpdateScore();
    }
    public void MealCompleted(bool correctOrder)
    {
        //Debug.Log(correctOrder);
        if (correctOrder)
        {
            ChangeScore(5f);
        } else
        {
            ChangeScore(-5f);
        }
    }
    /*
     * Create a visual alert to score change
     */
    public void CreateTransaction(float amount)
    {
        // Check if there is a prefab to instantiate 
        //if (textPrefab == null) { Debug.Log("ERROR: Transaction prefab is null"); return; }

       // GameObject createdText = Instantiate(textPrefab);
        //createdText.transform.SetParent(scoreText.transform);
        //createdText.transform.position = new Vector3(scoreText.transform.position.x + 25, scoreText.transform.position.y - 50, scoreText.transform.position.z) ;

        //Text cText = createdText.GetComponent<Text>();

        
        //Set up the UI Text

        //if (amount > 0.0)
        // Amount is positive
        //{
          //  cText.color = valueMealGreen;
         //   cText.text = $"+{amount.ToString("F2")}";
        //}
        //else 
        // Amount is negative
        //{
           // cText.color = refundRed;
          //  cText.text = $"{amount.ToString("F2")}";
        //}

        ChangeScore(amount);
    }

    private void ChangeScore(float amount)
    {
        playerScore += amount;
        UpdateScore();
    }


    private void UpdateScore()
    {
        scoreText.text = $"$ {playerScore.ToString("F2")}";

        if (playerScore > 0.0)
        // Amount is positive
        {
            scoreText.color = valueMealGreen;
        }
        else
        // Amount is negative
        {
            scoreText.color = refundRed;
        }

        if (playerScore < -100.00) { scoreText.text = "You Lose!"; scoreText.color = refundRed; director.gameOver = true; this.enabled = false; }
        if (playerScore > 10000.00) { scoreText.text = "You Win!"; scoreText.color = valueMealGreen; director.gameOver = true; this.enabled = false; }
    }

    

    public void ApplyPenalty()
    {
        CreateTransaction(penalty);
    }
}
