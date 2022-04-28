using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Randomizer : MonoBehaviour
{
    [SerializeField] private List<Sprite> s_sprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer m_sprite = null;
    // Start is called before the first frame update
    void Start()
    {
        //check if there is a sprite renderer
        if ((m_sprite = GetComponent<SpriteRenderer>()) == null) { return; }

        // select a new sprite at random from selection
        m_sprite.sprite = s_sprites[Random.Range(0, s_sprites.Count)];
    }

}
