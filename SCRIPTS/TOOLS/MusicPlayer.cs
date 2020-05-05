using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{

    static MusicPlayer instance = null;             //checks if there is another of the same object with MusicPlayer script
    private AudioSource audioSource;                //get and set AudioSource Component

    public Image musicRenderer;
    public Image soundRenderer;

    public Sprite[] musicImages;
    public Sprite[] soundImages;

    public bool active;                             //is it playing

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        musicRenderer.sprite = musicImages[0];
        soundRenderer.sprite = soundImages[0];

        //if there is another copy, destroy this object
        if (instance != null)
            Destroy(gameObject);
        else
        {
            //dont destroy this object
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //if active, stop playing, else keep playing
    public void ActivateAudio()
    {
        active = !active;

        if (active)
        {
            musicRenderer.sprite = musicImages[1];
            audioSource.Play();
        }
        else
        {
            musicRenderer.sprite = musicImages[0];
            audioSource.Stop();
        }
    }

    public void ActivateSound()
    {
        active = !active;

        if (active)
        {
            soundRenderer.sprite = soundImages[1];
            audioSource.Play();
        }
        else
        {
            soundRenderer.sprite = soundImages[0];
            audioSource.Stop();
        }
    }
}
