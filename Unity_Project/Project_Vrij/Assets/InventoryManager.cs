using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Orb> orbs = new List<Orb>();
    private int maxOrbs = 3;
    private int orbsInInventory = 0;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Inventory");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Add the names of all the orbs the orbs
        addOrb("Orb_1");
        addOrb("Orb_2");
        addOrb("Orb_3");
    }

    private void addOrb(string name)
    {
        orbs.Add(new Orb
        {
            orbName = name
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void recalculateInventoryCount()
    {
        int compareCount = 0;

        if(orbs.Count > 0)
        {
            foreach (Orb item in orbs)
            {
                if (item.isInInventory)
                {
                    compareCount++;
                }
            }
        }

        if(compareCount != orbsInInventory)
        {
            orbsInInventory = compareCount;
        }
    }
    
    public void pickUpOrb(string OrbName) //If being used from other script, check if the inventory has space with the public "hasInventorySpace()" function.
    {
        foreach(Orb item in orbs)
        {
            if(item.name == OrbName)
            {
                item.isInInventory = true;
                item.collected = true;
            }
        }
    }

    public void replaceOrb(string orbNameToReplace, string newOrbName) //use this function to switch orbs.
    {
        abandonOrb(orbNameToReplace);
        pickUpOrb(newOrbName);
    }

    public List<Orb> getOrbsInInventory()
    {
        List<Orb> tempList = new List<Orb>();

        foreach(Orb item in orbs)
        {
            if(item.collected && item.isInInventory)
            {
                tempList.Add(item);
            }
        }

        return tempList;
    }

    public void abandonOrb(string OrbName) //This can be used to replace orbs or to leave an orb behind.
    {
        foreach (Orb item in orbs)
        {
            if (item.name == OrbName)
            {
                item.isInInventory = false;
                item.collected = true;
            }
        }
    }

    public bool hasInventorySpace() //if a new orb is being picked up ALWAYS check if the inventory has space for it.
    {
        recalculateInventoryCount();

        if (orbsInInventory != maxOrbs)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
