using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{

    [Header("Score Manager")]
    private ScoreManager scoreManager = null;

    [Header("Sound")]
    private AudioSource audioSource = null;
    public List<AudioClip> soundClips = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void beAngry()
    {
        StartCoroutine(lerpFrustration());
    }
    public void playYell()
    {

    }
    public void playMoney()
    {

    }
    public void playGameLost()
    {

    }
    public void playGameWon()
    {

    }

    IEnumerator lerpFrustration()
    {
        yield return new WaitForSeconds(1);
    }
}
