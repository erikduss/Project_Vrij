using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> Level_1_Voice_Lines = new List<AudioClip>();
    private int currentVoiceLine = 0;
    private bool allowNextVoiceLine = false;
    public AudioSource nerrativeAudio;

    public List<GameObject> nerrativeBlockers = new List<GameObject>();

    public List<GameObject> nerrative3DPositions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentVoiceLine = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntroVoiceLinesLevel1()
    {
        nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
        currentVoiceLine++;

    }

    #region Level 1 Part 1
    public void VoiceLinesLevel1Part1()
    {
        nerrativeAudio.transform.position = nerrative3DPositions[0].transform.position;
        nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
        currentVoiceLine++;
        StartCoroutine(voiceLineLevel1Delay(6,false));
    }

    private IEnumerator deactivateBlocker(int blocker)
    {
        yield return new WaitForSeconds(2);
        if (nerrativeBlockers[blocker].activeInHierarchy == true)
        {
            nerrativeBlockers[blocker].SetActive(false);
        }
    }

        private IEnumerator voiceLineLevel1Delay(int delay, bool part4)
    {
        yield return new WaitForSeconds(delay);
        nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
        currentVoiceLine++;
        StartCoroutine(deactivateBlocker(0));
        if (part4)
        {
            //yield return new WaitForSeconds(7);
            //nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
            //currentVoiceLine++;
            //yield return new WaitForSeconds(3);
            //nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
            //currentVoiceLine++;
            //yield return new WaitForSeconds(3);
            //nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
            //currentVoiceLine++;
            //yield return new WaitForSeconds(4);
            //nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
            //currentVoiceLine++;
        }
    }
    #endregion

    public void VoiceLinesLevel1Part2()
    {
        nerrativeAudio.transform.position = nerrative3DPositions[0].transform.position;
        nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
        currentVoiceLine++;
        StartCoroutine(deactivateBlocker(1));
    }

    public void VoiceLinesLevel1Part3()
    {
        nerrativeAudio.transform.position = nerrative3DPositions[1].transform.position;
        nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
        currentVoiceLine++;
        StartCoroutine(deactivateBlocker(2));
    }

    public void VoiceLinesLevel1Part4()
    {
        nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[currentVoiceLine]);
        currentVoiceLine++;
        StartCoroutine(voiceLineLevel1Delay(5,true));
    }

    public void VoiceLinesLevel1End()
    {
        nerrativeAudio.PlayOneShot(Level_1_Voice_Lines[0]);
    }

}
