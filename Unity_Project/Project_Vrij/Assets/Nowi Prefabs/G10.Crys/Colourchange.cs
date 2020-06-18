using UnityEngine;

public class Colourchange : MonoBehaviour
{
    public Animator lightSwitch;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))lightSwitch.enabled = true;
    }
}
