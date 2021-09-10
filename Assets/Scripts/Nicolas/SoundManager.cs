using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource sourceMusic;
    public AudioSource source;

    [Header("Musique")]
    public AudioClip inGame;
    public AudioClip acceuil;

    [Header("COMBO")]
    public AudioClip combo;
    public AudioClip smoothy;
    public AudioClip delicat;
    public AudioClip delicieux;
    public AudioClip goutu;
    public AudioClip semiCroustillant;

    [Header("Aliments")]
    public AudioClip pain;
    public AudioClip fromage;
    public AudioClip steak;
    public AudioClip salade;
    public AudioClip beurre;
    public AudioClip saucicsse;
    public AudioClip jambon;
    public AudioClip fall1;
    public AudioClip fall2;
    public AudioClip fall3;

    [Header("Speciaux")]
    public AudioClip heureDePointe1;
    public AudioClip heureDePointe2;
    public AudioClip heureDePointe3;
    public AudioClip paysDeGalleIndependant;
    public AudioClip chef;
    public AudioClip crampe1;
    public AudioClip crampe2;
    public AudioClip comcombre;

    [Header("End")]
    public AudioClip win;
    public AudioClip lose;
    public AudioClip timer;


    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        sourceMusic.clip = acceuil;
        sourceMusic.loop = true;
        sourceMusic.Play();
    }

    private void Update()
    {
        if(Menu.instance.onMenu && sourceMusic.clip != acceuil)
        {
            sourceMusic.clip = acceuil;
            sourceMusic.Play();
        }
        else if(!Menu.instance.onMenu && sourceMusic.clip != inGame)
        {
            sourceMusic.clip = inGame;
            sourceMusic.Play();
        }
    }
}
