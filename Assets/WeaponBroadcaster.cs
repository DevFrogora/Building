using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //IMPORTANT

public class WeaponBroadcaster : MonoBehaviour
{
    public static WeaponBroadcaster instance;

    public event Action WeaponPick,WeaponDrop;

    private void Awake()
    {
        instance = this;
    }

    public void weaponPick()
    {
        WeaponPick?.Invoke();
    }
}
