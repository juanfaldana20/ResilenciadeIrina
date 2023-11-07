using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoController : MonoBehaviour
{
    public RawImage rawImage;
    public VideoClip videoClip;
    public string nextSceneName;

    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        videoPlayer.clip = videoClip;

        videoPlayer.loopPointReached += EndReached;

        // Reproduce el video
        videoPlayer.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        // Cambia a la siguiente escena cuando el video termina
        SceneManager.LoadScene(nextSceneName);
    }

    void Update()
    {
        // Muestra el video en el RawImage
        rawImage.texture = videoPlayer.targetTexture;
    }
}
