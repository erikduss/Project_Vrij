using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystemAran : MonoBehaviour
{
    [SerializeField] private PickAndPlayVideo _ppv;

    private bool canGrab = false;
    private GameObject grabableOrb;

    //variabele voor de ui allemaal op size 4 zetten deze zijn belangrijkst
    // inventoryslot uit het canvas in volgorde en als laatste NewOrb
    public List<GameObject> InventoryButtons;

    // Image die onder Inventoryslot en neworb zitten in volgorde met iamgeNewOrb als laatste
    public List<Image> UIOrbImage;

    // Description van de orbs in het canvas, van boven naar beneden in de hierarchy    
    public List<Text> OrbDescription;

    // Start is called before the first frame update
    void Start()
    {
        HideUI();
    }

    // Update is called once per frame
    void Update()
    {
        // kijkt eerst of er lege slots zijn pas bij 3 gevulde slots word de inventory geopend
        if (Input.GetKeyDown("e") && canGrab)
        {
            Debug.Log("knop werkt");
            if (CurrentOrbs.orbText1 == null)
            {
                CurrentOrbs.Orb1Image = grabableOrb.GetComponent<OrbInfo>().orbSprite;
                CurrentOrbs.orbText1 = grabableOrb.GetComponent<OrbInfo>().orbDescription;
            }
            else if (CurrentOrbs.orbText2 == null)
            {
                CurrentOrbs.Orb2Image = grabableOrb.GetComponent<OrbInfo>().orbSprite;
                CurrentOrbs.orbText2 = grabableOrb.GetComponent<OrbInfo>().orbDescription;
            }
            else if (CurrentOrbs.orbText3 == null)
            {
                CurrentOrbs.Orb3Image = grabableOrb.GetComponent<OrbInfo>().orbSprite;
                CurrentOrbs.orbText3 = grabableOrb.GetComponent<OrbInfo>().orbDescription;
            }
            else
            {
                Debug.Log("update werkt");
                UpdateShowUI();
            }
        }

        if (Input.GetKeyDown("r"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger werkt");
        if (other.gameObject.tag == "orb")
        {
            Debug.Log("tag werkt");
            grabableOrb = other.gameObject;
            canGrab = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "orb")
        {
            grabableOrb = null;
            canGrab = false;
        }
    }

    public void discardOrb1()
    {
        CurrentOrbs.Orb1Image = grabableOrb.GetComponent<OrbInfo>().orbSprite;
        CurrentOrbs.orbText1 = grabableOrb.GetComponent<OrbInfo>().orbDescription;
        Cursor.visible = false;
        HideUI();
        _ppv.PlayVideo();
    }

    public void discardOrb2()
    {
        CurrentOrbs.Orb2Image = grabableOrb.GetComponent<OrbInfo>().orbSprite;
        CurrentOrbs.orbText2 = grabableOrb.GetComponent<OrbInfo>().orbDescription;
        Cursor.visible = false;
        HideUI();
        _ppv.PlayVideo();
    }

    //Vervangt de 2e orb voor de nieuw opgepakte orb wanneer deze knop ingedrukt word
    public void discardOrb3()
    {
        CurrentOrbs.Orb3Image = grabableOrb.GetComponent<OrbInfo>().orbSprite;
        CurrentOrbs.orbText3 = grabableOrb.GetComponent<OrbInfo>().orbDescription;
        Cursor.visible = false;
        HideUI();
        _ppv.PlayVideo();
    }

    public void DiscardNewOrb()
    {
        HideUI();
        _ppv.NextScene();
    }

    private void HideUI()
    {
        foreach (GameObject Button in InventoryButtons)
        {
            Button.SetActive(false);
        }
    }

    void UpdateShowUI()
    {
        /*UIOrbImage[0].sprite = CurrentOrbs.InventoryOrb1.GetComponent<OrbInfo>().orbSprite;
        UIOrbImage[1].sprite = CurrentOrbs.InventoryOrb2.GetComponent<OrbInfo>().orbSprite;
        UIOrbImage[2].sprite = CurrentOrbs.InventoryOrb2.GetComponent<OrbInfo>().orbSprite;
        UIOrbImage[3].sprite = grabableOrb.GetComponent<OrbInfo>().orbSprite;

        OrbDescription[0].text = CurrentOrbs.InventoryOrb1.GetComponent<OrbInfo>().orbDescription;
        OrbDescription[1].text = CurrentOrbs.InventoryOrb2.GetComponent<OrbInfo>().orbDescription;
        OrbDescription[2].text = CurrentOrbs.InventoryOrb3.GetComponent<OrbInfo>().orbDescription;
        OrbDescription[3].text = grabableOrb.GetComponent<OrbInfo>().orbDescription;*/
        
        //check de opgeslagen variabelen om de ui icons en text te updaten
        UIOrbImage[0].sprite = CurrentOrbs.Orb1Image;
        UIOrbImage[1].sprite = CurrentOrbs.Orb2Image;
        UIOrbImage[2].sprite = CurrentOrbs.Orb3Image;
        UIOrbImage[3].sprite = grabableOrb.GetComponent<OrbInfo>().orbSprite;

        OrbDescription[0].text = CurrentOrbs.orbText1.ToString();
        OrbDescription[1].text = CurrentOrbs.orbText2.ToString();
        OrbDescription[2].text = CurrentOrbs.orbText3.ToString();
        OrbDescription[3].text = grabableOrb.GetComponent<OrbInfo>().orbDescription.ToString();

        Cursor.visible = true;
        foreach (GameObject Button in InventoryButtons)
        {
            Button.SetActive(true);
            }
        Debug.Log(CurrentOrbs.orbText1);
    }
}
