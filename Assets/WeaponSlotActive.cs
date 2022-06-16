using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotActive : MonoBehaviour
{

    public Image slot1Image;
    public Image slot2Image;


    private void Start()
    {
        UIBroadcast.instance.slot1AssultAdded += SetSlot1;
        UIBroadcast.instance.slot2AssultAdded += SetSlot2;

    }

    void SetSlot1(GameObject item)
    {
        slot1Image.sprite = item.GetComponent<IInventoryItem>().spriteImage;
    }

    void SetSlot2(GameObject item)
    {
        slot2Image.sprite = item.GetComponent<IInventoryItem>().spriteImage;
    }

    public void SlotActive1()
    {
        BagInventory.instance.ActiveSlot1(true);

    }

    public void SlotActive2()
    {
        BagInventory.instance.ActiveSlot2(true);
    }

}
