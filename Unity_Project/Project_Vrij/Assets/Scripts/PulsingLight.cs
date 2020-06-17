using UnityEngine;
using System.Collections;
public class PulsingLight : MonoBehaviour
{
    public bool startOn;
    public float maxBrightness;
    public float transitionTime;
    public float peakDelay;

    private bool isLit;

    public Light light;

    void Awake()
    {
        light = gameObject.GetComponent<Light>();
        isLit = startOn;
        light.intensity = isLit ? maxBrightness : 0;
    }

    void OnEnable()
    {
        StartCoroutine(Transition(!isLit));
    }

    void OnDisable()
    {
        StopAllCoroutines();
        isLit = false;
        light.intensity = 0;
    }

    IEnumerator Transition(bool turnOn)
    {
        float initialBrightness = light.intensity;
        float targetBrightness = turnOn ? maxBrightness : 0;
        float startTime = Time.time;
        float endTime = startTime + transitionTime;

        while (endTime >= Time.time)
        {
            light.intensity = Mathf.Lerp(initialBrightness, targetBrightness, (Time.time - startTime) / transitionTime);
            yield return null;
        }

        isLit = turnOn;
        yield return new WaitForSeconds(peakDelay);
        StartCoroutine(Transition(!isLit));
    }
}
