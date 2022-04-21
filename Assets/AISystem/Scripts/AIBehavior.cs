using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] private Restaurant_Manager director = null;

    public enum CustomerState {
        Arriving,
        Waiting,
        Eating,
        Leaving,
    }

    public enum BossState {
        Arriving,
        Yelling,
        Counting,
        Leaving,
    }

    [SerializeField] public CustomerState currentTask;
    [SerializeField] private float patience = 0;
    [SerializeField] public int waitPosition = -1;
    [SerializeField] public int standPosition = -1;
    [SerializeField] public int seatPosition = -1;

    // Start is called before the first frame update

    public Vector3 positionToMoveTo;
    void Start()
    {
        director = GameObject.Find("Resturant_Position_Manager").GetComponent<Restaurant_Manager>();

        // If director not found, escape 
        if (director == null) { return; }
        // If no position, escape
        if (positionToMoveTo == null) { return; }


        // Move towards position in line
        MoveNextPosition();
        // Assign AI to wait in line
        //currentTask = CustomerState.Arriving;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while(time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time/duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Final snap into position
        transform.position = targetPosition;

        // only first person calls 
        if (waitPosition == 0)
        {
            // Evaluate my position
            director.EvaluateMyPosititon(gameObject);
        }
    }

    public void MoveNextPosition()
    {
        StartCoroutine(LerpPosition(positionToMoveTo, 5));
        Debug.Log("MoveNextPosition() called!");
    }

    public void ChangeTargetPosition(Vector3 targetPos)
    {
        Debug.Log(targetPos);
        positionToMoveTo = targetPos;
    }

    
}
