using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private SoundManager soundManager;
    public int storyProgress = 0;

    public GameObject fadePanel;
    private Image panelImage;

    private bool ending = false;

    public int currentScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = this.gameObject.GetComponent<SoundManager>();
        storyProgress = -1;
        //panelImage = fadePanel.GetComponent<Image>();
        //fadePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(storyProgress < 0)
        {
            storyProgress++;
            //soundManager.IntroVoiceLinesLevel1();
        }

        if (ending)
        {
            //panelImage.CrossFadeAlpha(1, 2.5f, false);
        }
    }

    public void EndDemo()
    {
        //fadePanel.SetActive(true);
        //Color fixedColor = panelImage.color;
       // fixedColor.a = 1;
       //panelImage.color = fixedColor;
       //panelImage.CrossFadeAlpha(0, 0.0f, false);

        soundManager.VoiceLinesLevel1End();
        ending = true;
    }

    public void LoadNextLevel()
    {
        int nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void NextStoryVoiceLines()
    {
        storyProgress++;
        switch (storyProgress)
        {
            case 1:
                soundManager.VoiceLinesLevel1Part1();
                break;
            case 2:
                soundManager.VoiceLinesLevel1Part2();
                break;
            case 3:
                soundManager.VoiceLinesLevel1Part3();
                break;
            case 4:
                soundManager.VoiceLinesLevel1Part4();
                break;
        }
    }
}
