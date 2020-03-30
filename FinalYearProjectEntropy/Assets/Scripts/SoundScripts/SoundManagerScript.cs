using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling all sounds
// Reference : https://www.youtube.com/watch?v=8pFlnyfRfRc - for managing sounds with switch cases
public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip skelSmallDie;
    public static AudioClip skelRun;
    public static AudioClip zombieDie;
    public static AudioClip zombieRun;
    public static AudioClip swing;
    public static AudioClip bigSwing;
    public static AudioClip chest;
    public static AudioClip potion;
    public static AudioClip cave1;
    public static AudioClip cave2;
    public static AudioClip fight1;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // get audio clip sources
        skelSmallDie = Resources.Load<AudioClip>("Skeleton_die");
        skelRun = Resources.Load<AudioClip>("Skeleton_Run");
        zombieDie = Resources.Load<AudioClip>("Zombie_Die1");
        zombieRun = Resources.Load<AudioClip>("Zombie_Run");
        swing = Resources.Load<AudioClip>("Swing");
        bigSwing = Resources.Load<AudioClip>("BigSwing");
        chest = Resources.Load<AudioClip>("Chest");
        potion = Resources.Load<AudioClip>("Potion");
        cave1 = Resources.Load<AudioClip>("Cave1");
        cave2 = Resources.Load<AudioClip>("Cave2");
        fight1 = Resources.Load<AudioClip>("Fight1");

        // get audio source component
        audioSrc = GetComponent<AudioSource>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        // switch statement for audio clips
        switch (clip)
        {
            case "Skeleton_die":
                audioSrc.PlayOneShot(skelSmallDie);
                break;
            case "Skeleton_Run":
                audioSrc.PlayOneShot(skelRun);
                break;
            case "Zombie_Die1":
                audioSrc.PlayOneShot(zombieDie);
                break;
            case "Zombie_Run":
                audioSrc.PlayOneShot(zombieRun);
                break;
            case "Swing":
                audioSrc.PlayOneShot(swing);
                break;
            case "Chest":
                audioSrc.PlayOneShot(chest);
                break;
            case "Potion":
                audioSrc.PlayOneShot(potion);
                break;
            case "BigSwing":
                audioSrc.PlayOneShot(bigSwing);
                break;
            case "Cave1":
                audioSrc.PlayOneShot(cave1);
                break;
            case "Cave2":
                audioSrc.PlayOneShot(cave2);
                break;
            case "Fight1":
                audioSrc.PlayOneShot(fight1);
                break;
        }
    }
}
