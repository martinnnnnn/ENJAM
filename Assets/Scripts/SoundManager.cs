using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{



    public AudioClip[] clips;


    static private AudioSource audio;

    void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    

	public void playsound(string name, float delay = 0f)
    {

        StartCoroutine(PlaySound(name, delay));


        //foreach (AudioClip clip in clips)
        //{
        //    if (clip.name == name)
        //    {
        //        audio.PlayOneShot(clip);
        //    }
        //}
    }


    IEnumerator PlaySound(string name, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        foreach (AudioClip clip in clips)
        {
            if (clip.name == name)
            {
                audio.PlayOneShot(clip);
            }
        }
    }


    public static void PlaySoundOnce(string name, float delay = 0f)
    {

        SoundManager soundman = FindObjectOfType<SoundManager>();
        soundman.playsound(name);
    }
}
