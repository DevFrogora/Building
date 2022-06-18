using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot2UIUpdater : MonoBehaviour
{
    public Image assult;
    public Image ExtendedMag;
    public Image Sight;

    private void Start()
    {
        BagUIBroadcast.instance.slot2AssultAdded += SetAssult;
    }

    void SetAssult(GameObject item)
    {
        assult.sprite = item.GetComponent<IInventoryItem>().spriteImage;
    }
}