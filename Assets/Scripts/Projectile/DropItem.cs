using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public WeaponUnlocker ItemToDrop;
    public GameObject Unlock;
    public GameObject UI;

    public void Drop()
    {
        Instantiate(ItemToDrop, transform.position + Vector3.up, transform.rotation);
        ItemToDrop.Unlockable = Unlock.gameObject;
        ItemToDrop.UIUnlock = UI.gameObject;
    }
}
