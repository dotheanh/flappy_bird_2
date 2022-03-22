using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip sfxDie, sfxHit, sfxPoint, sfxSwooshing, sfxWing;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        sfxDie = Resources.Load<AudioClip>("sfxDie");
        sfxHit = Resources.Load<AudioClip>("sfxHit");
        sfxPoint = Resources.Load<AudioClip>("sfxPoint");
        sfxSwooshing = Resources.Load<AudioClip>("sfxSwooshing");
        sfxWing = Resources.Load<AudioClip>("sfxWing");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "die":
                audioSrc.PlayOneShot(sfxDie);
                break;
            case "hit":
                audioSrc.PlayOneShot(sfxHit);
                break;
            case "point":
                audioSrc.PlayOneShot(sfxPoint);
                break;
            case "swooshing":
                audioSrc.PlayOneShot(sfxSwooshing);
                break;
            case "swing":
                audioSrc.PlayOneShot(sfxWing);
                break;
            default: break;
        }
    }
}
