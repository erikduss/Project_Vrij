using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemAran : MonoBehaviour
{

    public Orb orbGrot1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "orb" && Input.GetKeyDown("e"))
        {
            CurrentOrbs.orb1 = orbGrot1;
        }
    }
}
