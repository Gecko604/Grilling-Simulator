using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] private List<AudioClip> IdleSounds = new List<AudioClip>();
    [SerializeField] public  AudioSource audioSource = null;
    [SerializeField] private Restaurant_Manager director = null;

    public enum CustomerState {
        Moving,
        Waiting,
        Standing
    }

    public enum BossState {
        Arriving,
        Yelling,
        Counting,
        Leaving,
    }

    [SerializeField] public CustomerState currentTask = CustomerState.Moving;
    [SerializeField] private float patience = 0;
    [SerializeField] public int waitPosition = -1;
    [SerializeField] public int standPosition = -1;
    [SerializeField] public int seatPosition = -1;
    [SerializeField] public int timeToMove = 4;

    // Start is called before the first frame update

    public Vector3 positionToMoveTo;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(playSound());

        director = GameObject.Find("Resturant_Position_Manager").GetComponent<Restaurant_Manager>();
        //orderMenu = GameObject.Find("Order Holder").GetComponent<orderManager>();

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
        currentTask = CustomerState.Moving;

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
        // Signal customer is now waiting
        currentTask = CustomerState.Waiting;
        // Tell manager to check line - fails, only runs successfully on last customer ready
        checkLine();
        // only first person calls 
        if (waitPosition == 0)
        {
            // Evaluate my position
            //director.EvaluateMyPosititon(gameObject);
        }
    }

    private void checkLine()
    {
        director.EvaluateLine();
    }
    public void MoveNextPosition()
    {
        StartCoroutine(LerpPosition(positionToMoveTo, timeToMove));
       // Debug.Log("MoveNextPosition() called!");
    }

    public void ChangeTargetPosition(Vector3 targetPos)
    {
        Debug.Log(targetPos);
        positionToMoveTo = targetPos;
    }

    IEnumerator playSound()
    {
        int randomTime = Random.Range(10, 45);



        yield return new WaitForSeconds(randomTime);

        int ran = Random.Range(0, IdleSounds.Count);

        audioSource.clip = IdleSounds[ran];

        audioSource.Play();

    }
}
