using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFX : MonoBehaviour
{
    public static BackgroundFX instance;
    public AudioSource myFx;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Comentado para poder permitir el cambio de idioma.
        DontDestroyOnLoad(gameObject);
    }

    public void Pause()
    {
        myFx.Pause();
    }

    public void Unpause()
    {
        myFx.UnPause();
    }
}
