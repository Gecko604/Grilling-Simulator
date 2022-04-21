using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillSoundController : MonoBehaviour
{

    [Header("Sounds")]
    public AudioClip touchGrill;

    [Header("Prefab")]
    public GameObject soundPlayer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TouchGrill(Collider other)
    {
        GameObject scream = Instantiate(soundPlayer, other.transform.position, other.transform.rotation) as GameObject;
        scream.GetComponent<AudioSource>().PlayOneShot(touchGrill);
        while(scream.GetComponent<AudioSource>().isPlaying)
        Destroy(scream);
    }
}
