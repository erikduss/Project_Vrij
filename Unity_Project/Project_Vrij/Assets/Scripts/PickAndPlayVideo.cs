

using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.Video; using UnityEngine.UI; using UnityEngine.SceneManagement;  public class PickAndPlayVideo : MonoBehaviour {      public VideoClip _vc;     public VideoClip orb;     public VideoPlayer _vp;      public string sceneToLoad;      [SerializeField] private Image fadePanel;

    [SerializeField] private InventorySystemAran _is;
    [SerializeField] private UnityStandardAssets.Characters.FirstPerson.FirstPersonController _fpc;       private void Awake()
    {
        fadePanel = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Image>();
    }     public void PlayVideo()     {         StartCoroutine(PlayToLength(_vc, 1, false));            }      public void NextScene()     {         StartCoroutine(FadePanel(sceneToLoad));      }      public void NormalVideo(bool _continue)      {         StartCoroutine(PlayCaveVideo(_continue));
     }      public void OrbVideo(bool _continue)     {         StartCoroutine(PlayOrbVideo(_continue));     }       public IEnumerator PlayCaveVideo(bool _continue)     {         _vp.clip = _vc;         _vp.Play();
        _fpc.endDemo = true;
        _fpc.pickupText.enabled = false;         yield return new WaitForSeconds((float)_vp.clip.length);         //         _vp.Stop();
        _fpc.endDemo = false;
        _fpc.pickupText.enabled = true;
        _is.canGrab = true;         if(_continue)             StartCoroutine(PlayToLength(orb, 1, true));     }      public IEnumerator PlayOrbVideo(bool _continue)     {         _vp.clip = orb;         _vp.Play();
        _fpc.endDemo = true;
        _fpc.pickupText.enabled = false;         yield return new WaitForSeconds((float)_vp.clip.length);         //         //_vp.Stop();
         if (_continue)             StartCoroutine(FadePanel(sceneToLoad));      }      private IEnumerator PlayToLength(VideoClip clip, float playbackSpeed, bool stopAfter)     {         _vp.playbackSpeed = playbackSpeed;         _vp.clip = clip;         _vp.Play();
        //_fpc.endDemo = true;         Debug.Log((float)_vc.length / playbackSpeed);         yield return new WaitForSeconds((float)_vc.length / playbackSpeed);         _vp.Stop();                 if (stopAfter)         {             StartCoroutine(FadePanel(sceneToLoad));             yield return null;         }else if (!stopAfter) {             if (orb == null)                 StartCoroutine(FadePanel(sceneToLoad));             if(orb != null)             StartCoroutine(PlayToLength(orb, 1, true));             Debug.Log("3");         }          //plays orb animation and stops                 // Debug.Log("video done playing");     }       private IEnumerator FadePanel(string scene)     {          for (float i = 0; i <= 1; i += Time.deltaTime)         {              fadePanel.color = new Color(0, 0, 0, i);             yield return null;          }         yield return new WaitForSeconds(2);         SceneManager.LoadScene(scene);     } }    