using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [Header("UI Elements")]
    public Text scoreText;
    public Text scoreGrade;

    [Header("Level Information")]
    public float maxLevelScore = 0;
    public int numOrders = 0;

    [Header("Customer Stats")]
    public int happyCustomers = 0;
    public int satisfiedCustomers = 0;
    public int annoyedCustomers = 0;
    public int angryCustomers = 0;

    [Header("Player Information")]
    public float playerScore = 0.0f;
    public float customerRating = 0.0f;

    [Header("Payment Information")]
    public GameObject textPrefab = null;
    public Color refundRed = Color.red;
    public Color valueMealGreen = Color.green;

    public void Start()
    {
        UpdateScore();
        createTransaction(-4.75f);
    }
    public void MealCompleted(int customerReceipt, int customerSatisfaction)
    {
        //Customer has a bill, and that bill is modifed with a tip or refund based off customer satisfaction

        //If the customer is angry, a refund will be issued and the meal's value will be subtracted from score
        if (customerSatisfaction == 1)
        {
            ChangeScore(customerReceipt);
            angryCustomers++;
        }
        // If the customer is annoyed, they will add the value of the meal, but leave no tip
        if (customerSatisfaction == 2)
        {
            ChangeScore(customerReceipt * 1.0f);
            annoyedCustomers++;
        }
        // If the customer is satisfied, they will add the value of the meal and leave a 10% tip
        if (customerSatisfaction == 3)
        {
            ChangeScore(customerReceipt * 1.1f);
            satisfiedCustomers++;
        }
        // If the customer is happy, they will add the value of the meal and leave a 30% tip
        if (customerSatisfaction == 4)
        {
            ChangeScore(customerReceipt * 1.3f);
            happyCustomers++;
        }
    }
    /*
     * Create a visual alert to score change
     */
    private void createTransaction(float amount)
    {
        // Check if there is a prefab to instantiate 
        if (textPrefab == null) { Debug.Log("ERROR: Transaction prefab is null"); return; }

        GameObject createdText = Instantiate(textPrefab);
        createdText.transform.SetParent(scoreText.transform);
        createdText.transform.position = new Vector3(scoreText.transform.position.x + 25, scoreText.transform.position.y - 50, scoreText.transform.position.z) ;

        Text cText = createdText.GetComponent<Text>();

        
        //Set up the UI Text

        if (amount > 0.0)
        // Amount is positive
        {
            cText.color = valueMealGreen;
            cText.text = $"+{amount.ToString("F2")}";
        }
        else 
        // Amount is negative
        {
            cText.color = refundRed;
            cText.text = $"{amount.ToString("F2")}";
        }

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
    }

    public void GradeScore()
    {
        // F.U.N - Grade scaling 

        // F stands for: Fine
        // U stands for: unsatisfactory
        // N stands for: not good enough

        //Grade Letter is dependant on final score's % of the total avaliable points

        if (playerScore / maxLevelScore >= 0.9)
        {

        } else if (playerScore / maxLevelScore >= 0.8)
        {

        } else
        {
            // Taunted by Mr. Krustacean


        }



    }
}
