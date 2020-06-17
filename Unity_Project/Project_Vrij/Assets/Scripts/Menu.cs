using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{ 
[SerializeField]private Image fadePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        StartCoroutine(FadePanel());
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Grot_1");
    }

    private IEnumerator FadePanel() {

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {

            fadePanel.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }



}
