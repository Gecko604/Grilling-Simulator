using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillSoundController : MonoBehaviour
{

    [Header("Sounds")]
    public AudioClip touchGrill;
    public AudioClip cashSound;

    [Header("Prefab")]
    public GameObject soundPlayer;
    public SoundDestroyer destroy;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TouchGrill(Collider other)
    {
        GameObject scream = Instantiate(soundPlayer, other.transform.position, other.transform.rotation) as GameObject;
        print("Instantiate: " + scream);
        scream.GetComponent<AudioSource>().PlayOneShot(touchGrill);
        destroy = scream.GetComponent<SoundDestroyer>();
        StartCoroutine(destroy.DelayandDestroy(touchGrill.length));
    }

    public void IncreaseCashSound(GameObject other)
    {
        GameObject chaching = Instantiate(soundPlayer, other.transform.position, other.transform.rotation) as GameObject;
        print("Instantiate: " + chaching);
        chaching.GetComponent<AudioSource>().PlayOneShot(cashSound);
        StartCoroutine(destroy.DelayandDestroy(cashSound.length));
    }

    
}
