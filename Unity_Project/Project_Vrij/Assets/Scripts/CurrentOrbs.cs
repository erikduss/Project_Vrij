using UnityEngine;
using UnityEngine.UI;
public class CurrentOrbs : MonoBehaviour
{

    public static GameObject InventoryOrb1;
    public static GameObject InventoryOrb2;
    public static GameObject InventoryOrb3;

    public static Sprite Orb1Image;
    public static Sprite Orb2Image;
    public static Sprite Orb3Image;

    public static string orbText1;
    public static string orbText2;
    public static string orbText3;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

