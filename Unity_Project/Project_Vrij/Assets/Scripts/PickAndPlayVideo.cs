using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickAndPlayVideo : MonoBehaviour
{

    public VideoClip _vc;
    public VideoClip orb;
    public VideoPlayer _vp;

    public string sceneToLoad;

    [SerializeField] private Image fadePanel;



    public void PlayVideo()
    {
        StartCoroutine(PlayToLength(_vc, 1, false));
      
    }

    private IEnumerator PlayToLength(VideoClip clip, float playbackSpeed, bool stopAfter)
    {
        _vp.playbackSpeed = playbackSpeed;
        _vp.clip = clip;
        _vp.Play();
        yield return new WaitForSeconds((float)_vc.length / playbackSpeed);
        _vp.Stop();
        //if (stopAfter)
        //{
        //    Debug.Log("stopping");
        //    yield return null;
        //}
        if (stopAfter)
        {
            StartCoroutine(FadePanel(sceneToLoad));
            yield return null;
        }else if (!stopAfter) {
            StartCoroutine(PlayToLength(orb, 2, true));
        }

        //plays orb animation and stops
       
        // Debug.Log("video done playing");
    }


    private IEnumerator FadePanel(string scene)
    {

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {

            fadePanel.color = new Color(0, 0, 0, i);
            yield return null;

        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }
}
