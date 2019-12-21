using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {

        videoPlayer.loopPointReached += EndReached;

    }

    void EndReached(VideoPlayer videoPlayer)
    {
        SceneManager.LoadScene("MainScene");
    }
}
