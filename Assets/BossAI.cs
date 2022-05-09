using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{

    [Header("Score Manager")]
    private ScoreManager scoreManager = null;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource = null;
    public List<AudioClip> soundClips = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        imReady();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void imReady()
    {
        audioSource.clip = soundClips[4];
        audioSource.Play();
    }
    private void Scare()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        Vector3 pos = new Vector3(-2f, 1.5f, 5f);
        StartCoroutine(LerpPosition(pos, 1));
    }

    public void playFired()
    {
        audioSource.clip = soundClips[0];
        audioSource.Play();
    }
    public void playMoney()
    {
        audioSource.clip = soundClips[2];
        audioSource.Play();
    }

    public void playOuch()
    {
        audioSource.clip = soundClips[3];
        audioSource.Play();
        StartCoroutine(stopAudio(6.7f));
    }
    public void playGameLost()
    {
        playFired();
        Scare();
    }
    public void playGameWon()
    {
        Scare();
        playMoney();
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    { 

        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f,1f,1f), time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Final snap into position
        transform.position = targetPosition;
    }

    IEnumerator lerpFrustration()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator countMoney()
    {
        yield return new WaitForSeconds(5);
        playMoney();
    }

    IEnumerator stopAudio(float duration)
    {
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
    }
}
