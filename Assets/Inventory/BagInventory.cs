using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagInventory : MonoBehaviour
{
    // we have to make it scriptableObject
    public static BagInventory instance;

    private void Awake()
    {
        instance = this;
    }

    public int MaxSize;
    public int currentSize;

    [System.Serializable]
    public class AssultSlot
    {
        public GameObject assultPrefab;
        public GameObject extendedMag;
        public GameObject supressor;
        public GameObject sight;

    }

    public class PistolSlot
    {
        public GameObject pistolPrefab;
        public GameObject extendedMag;
        public GameObject sight;

    }

    public AssultSlot slot1;
    public AssultSlot slot2;
    public PistolSlot slot3;

    public bool activeSlot1;
    public bool activeSlot2;
    public bool activeSlot3;



    public void ActiveSlot1(bool _activeSlot1)
    {
        activeSlot1 = _activeSlot1;
        if (_activeSlot1)
        {
            activeSlot2 = false;
            activeSlot3 = false;
        }

    }
    public void ActiveSlot2(bool _activeSlot2)
    {
        activeSlot2 = _activeSlot2;
        if(_activeSlot2)
        {
            activeSlot1 = false;
            activeSlot3 = false;
        }

    }


    public List<GameObject> AllItem = new List<GameObject>();

    public void SetSlot1Assult(GameObject weapon)
    {
        //if(slot1.assultPrefab != null)
        //{
        //    //Drop The item If destroy
        //    Destroy(slot1.assultPrefab.gameObject);
        //}
        if (weapon == null)
        {
            slot1.assultPrefab = null;
            BagUIBroadcast.instance.Slot1AssultAdded(weapon);
        }
        else {
            if (weapon.GetComponent<m416>())
            {
                slot1.assultPrefab = weapon;
                BagUIBroadcast.instance.Slot1AssultAdded(weapon);
            }
        } 
    }

    //public void SetSlot1ExtendedMag(GameObject mag)
    //{
    //    //if (slot1.extendedMag != null)
    //    //{
    //    //    //Drop The item If destroy
    //    //    Destroy(slot1.extendedMag.gameObject);
    //    //}
    //    if (mag.GetComponent<ExtendedMag>())
    //    {
    //        slot1.extendedMag = mag;
    //    }
    //}

    //public void SetSlot1SightMag(GameObject sight)
    //{
    //    //if (slot1.extendedMag != null)
    //    //{
    //    //    //Drop The item If destroy
    //    //    Destroy(slot1.extendedMag.gameObject);
    //    //}
    //    if (sight.GetComponent<ExtendedMag>())
    //    {
    //        slot1.extendedMag = sight;
    //    }
    //}


    public void SetSlot2Assult(GameObject weapon)
    {
        if (weapon == null)
        {
            slot2.assultPrefab = null;
            BagUIBroadcast.instance.Slot2AssultAdded(weapon);
        }
        else
        {
            if (weapon.GetComponent<m416>())
            {
                slot2.assultPrefab = weapon;
                BagUIBroadcast.instance.Slot2AssultAdded(weapon);
            }
        }

    }

}
