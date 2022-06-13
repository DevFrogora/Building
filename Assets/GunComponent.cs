using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    [Header("Attachment")]
    public GameObject sight;

    void AttachSight(GameObject _sight)
    {
        if(sight != null)
        {
            Destroy(sight);
        }
        sight = _sight;
    }

    void RemoveSight()
    {
        sight = null;
    }

}
