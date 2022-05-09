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

    private void Scare()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.position = new Vector3(-3.75f, 1f, 5f);

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
