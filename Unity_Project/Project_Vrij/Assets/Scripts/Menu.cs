using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{


[SerializeField]private Image fadePanel;
    [SerializeField] private string sceneToLoad;

    [SerializeField] private Image playButton;

    [SerializeField] private PickAndPlayVideo _ppv;

   



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(OnGameStart());
        }

    }

    private IEnumerator OnGameStart()
    {
        //StartCoroutine(FadePanel());

        yield return new WaitForSeconds(0);
        _ppv.PlayVideo();
    }

    private IEnumerator FadePanel() {

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {

            fadePanel.color = new Color(0, 0, 0, i);
            yield return null;
            
        }
    }



}
