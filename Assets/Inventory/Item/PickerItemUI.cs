using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PickerItemUI : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Image image;

    public GameObject itemPrefab;

    public void onClick()
    {
        //its UI For PickupItem

        if (itemPrefab.GetComponent<m416>())
        {
            if (BagInventory.instance.activeSlot1)
            {
                // Cloned it and Destory it or pickup the this prefab;
                BagInventory.instance.SetSlot1Assult(itemPrefab);
            }
            if (BagInventory.instance.activeSlot2)
            {
                BagInventory.instance.SetSlot2Assult(itemPrefab);
            }
        }

    }
}
