using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour {

    public static BackgroundMusicController instance;
    public GameObject soundObject;
    public AudioSource audioSource;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        soundObject = GameObject.Find("BackgroundMusic");
        audioSource = soundObject.GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
